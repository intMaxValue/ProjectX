using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Contracts;
using ProjectX.Core.Services;
using ProjectX.ViewModels.Salon;
using System.Security.Claims;
using ProjectX.Infrastructure.Data.Models;

namespace ProjectX.Controllers
{
    public class MySalonController : Controller
    {
        private readonly ISalonService _salonService;
        private readonly ImageUploader _imageUploader;
        private readonly UserManager<User> _userManager;

        public MySalonController(ISalonService salonService, ImageUploader imageUploader, UserManager<User> userManager)
        {
            _salonService = salonService;
            _imageUploader = imageUploader;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Retrieve salons owned by the current user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var salons = await _salonService.GetAllSalonsByOwnerIdAsync(userId);

            // Check if salons are found for the current user
            if (salons == null || !salons.Any())
            {
                // If no salons are found, return a view indicating that the user has no salons
                return View("NoSalonsFound");
            }

            // Project the salons to the MySalonViewModel
            var mySalonViewModels = salons.Select(s => new MySalonViewModel
            {
                SalonId = s.Id,
                SalonName = s.Name,
                City = s.City,
                Address = s.Address,
                PhoneNumber = s.PhoneNumber,
                Description = s.Description,
                MapUrl = s.MapUrl,
                ProfilePictureUrl = s.ProfilePictureUrl,
                Photos = s.Photos.Select(p => new PhotoViewModel
                {
                    Id = p.Id,
                    Url = p.Url,
                    Caption = p.Caption,
                    DateUploaded = p.DateUploaded
                }).ToList()
            }).ToList();

            // Pass the list of all salons to the view
            ViewBag.SalonList = mySalonViewModels;

            // Render the first salon by default
            var firstSalon = mySalonViewModels.FirstOrDefault();

            // Pass the first salon to the view
            return View(firstSalon);
        }

        [HttpGet]
        public async Task<IActionResult> GetSalonDetails(int id)
        {
            // Get the salon details by ID
            var salon = await _salonService.GetSalonByIdAsync(id);

            // Check if the salon exists
            if (salon == null)
            {
                // If the salon does not exist, return a not found response
                return NotFound();
            }

            // Map the salon to the MySalonViewModel
            var viewModel = new MySalonViewModel
            {
                SalonId = salon.Id,
                SalonName = salon.Name,
                City = salon.City,
                Address = salon.Address,
                PhoneNumber = salon.PhoneNumber,
                Description = salon.Description,
                MapUrl = salon.MapUrl,
                ProfilePictureUrl = salon.ProfilePictureUrl,
                Photos = salon.Photos.Select(p => new PhotoViewModel
                {
                    Id = p.Id,
                    Url = p.Url,
                    Caption = p.Caption,
                    DateUploaded = p.DateUploaded
                }).ToList()
            };

            // Return a partial view with the salon details
            return PartialView("_SalonDetailsPartial", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoto(int salonId, IFormFile photo, string caption)
        {
            // Retrieve the current user
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            string userId = currentUser.Id;

            // Check if the current user is the owner of the salon
            var salon = await _salonService.GetSalonByIdAsync(salonId);
            if (salon.OwnerId != userId)
            {
                // Return unauthorized if the user is not the owner of the salon
                return Unauthorized();
            }

            try
            {
                // Upload photo
                string photoUrl = await _imageUploader.UploadImageAsync(photo);

                // Add photo to the salon
                await _salonService.AddPhotoToSalonAsync(salonId, photoUrl, userId, caption);

                // Redirect back to the salon profile page
                return RedirectToAction("Index", "MySalon");
            }
            catch (Exception)
            {
                // Handle errors appropriately
                ModelState.AddModelError("", "An error occurred while adding the photo to the salon.");
                return RedirectToAction("Index", "MySalon");
            }
        }

    }
}
