using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Contracts;
using ProjectX.Core.Services;
using ProjectX.ViewModels.Salon;
using System.Security.Claims;
using User = ProjectX.Infrastructure.Data.Models.User;

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

        public async Task<IActionResult> Index(int salonId)
        {
            // Retrieve salons owned by the current user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var salons = await _salonService.GetAllSalonsByOwnerIdAsync(userId);

            // Check if salons are found for the current user
            if (salons == null || !salons.Any())
            {
                return BadRequest();
            }

            // If no specific salon ID is provided or if the provided ID is invalid, 
            // render the first salon by default
            var selectedSalon = salons.FirstOrDefault(s => s.Id == salonId);
            if (selectedSalon == null)
            {
                selectedSalon = salons.First(); // Render the first salon if no matching salon is found
            }

            // Project the selected salon to the MySalonViewModel
            var mySalonViewModel = new MySalonViewModel
            {
                SalonId = selectedSalon.Id,
                SalonName = selectedSalon.Name,
                City = selectedSalon.City,
                Address = selectedSalon.Address,
                PhoneNumber = selectedSalon.PhoneNumber,
                Description = selectedSalon.Description,
                MapUrl = selectedSalon.MapUrl,
                ProfilePictureUrl = selectedSalon.ProfilePictureUrl,
                Photos = selectedSalon.Photos.Select(p => new PhotoViewModel
                {
                    Id = p.Id,
                    Url = p.Url,
                    Caption = p.Caption,
                    DateUploaded = p.DateUploaded
                }).ToList()
            };

            // Pass the list of all salons and the selected salon to the view
            ViewBag.SalonList = salons.Select(s => new MySalonViewModel
            {
                SalonId = s.Id,
                SalonName = s.Name
            }).ToList();

            // Pass the selected salon to the view
            return View(mySalonViewModel);
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
                return RedirectToAction("Index", "MySalon", new { salonId = salonId });
            }
            catch (Exception)
            {
                // Handle errors appropriately
                ModelState.AddModelError("", "An error occurred while adding the photo to the salon.");
                return RedirectToAction("Index", "MySalon", new { salonId = salonId });
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditSalon(int id)
        {
            // Get the salon details by ID
            var salon = await _salonService.GetSalonByIdAsync(id);

            // Check if the salon exists
            if (salon == null)
            {
                // If the salon does not exist, return a not found response
                return NotFound();
            }

            // Map the salon to the CreateSalonViewModel
            var viewModel = new CreateSalonViewModel
            {
                Name = salon.Name,
                City = salon.City,
                Address = salon.Address,
                PhoneNumber = salon.PhoneNumber,
                Description = salon.Description,
                MapUrl = salon.MapUrl,
                OwnerId = salon.OwnerId,
                ProfilePictureUrl = salon.ProfilePictureUrl
            };

            // Return the view with the populated ViewModel
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditSalon(int id, CreateSalonViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return the form with validation errors
                return View(viewModel);
            }

            // Get the existing salon by ID
            var existingSalon = await _salonService.GetSalonByIdAsync(id);

            // Check if the salon exists
            if (existingSalon == null)
            {
                // If the salon does not exist, return a not found response
                return NotFound();
            }

            // Update the salon properties with the values from the ViewModel
            existingSalon.Name = viewModel.Name;
            existingSalon.City = viewModel.City;
            existingSalon.Address = viewModel.Address;
            existingSalon.PhoneNumber = viewModel.PhoneNumber;
            existingSalon.Description = viewModel.Description;
            existingSalon.MapUrl = viewModel.MapUrl;

            if (viewModel.NewProfilePicture != null)
            {
                string newProfilePictureUrl = await _imageUploader.UploadImageAsync(viewModel.NewProfilePicture);
                existingSalon.ProfilePictureUrl = newProfilePictureUrl;
            }

            // Update the salon in the database
            await _salonService.UpdateSalonAsync(existingSalon);

            // Redirect to the salon details page
            return RedirectToAction("Index", new { salonId = id });
        }

    }
}
