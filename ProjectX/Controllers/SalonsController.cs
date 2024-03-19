using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Contracts;
using ProjectX.Core.Services;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Salon;

namespace ProjectX.Controllers
{
    public class SalonsController : Controller
    {
        private readonly ISalonService _salonService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ImageUploader _imageUploader;
        public SalonsController(ISalonService salonService, UserManager<IdentityUser> userManager, ImageUploader imageUploader)
        {
            _salonService = salonService;
            _userManager = userManager;
            _imageUploader = imageUploader; 
        }

        public async Task<IActionResult> Index(string searchQuery)
        {
            var salons = await _salonService.GetAllSalonsAsync(searchQuery);

            var salonViewModels = salons.Select(s => new SalonViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                City = s.City,
                PhoneNumber = s.PhoneNumber,
                Description = s.Description,
                MapUrl = s.MapUrl,
                ProfilePictureUrl = s.ProfilePictureUrl,
            });

            return View(salonViewModels);
        }

        public async Task<IActionResult> Create()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            string userId = currentUser.Id;
            ViewBag.UserId = userId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSalonViewModel model, IFormFile profilePicture)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            string userId = currentUser.Id;

            model.OwnerId = userId;

            model.ProfilePictureUrl = string.Empty;

            if (ModelState.IsValid && userId != null)
            {
                try
                {
                    string profilePictureUrl = await _imageUploader.UploadImageAsync(profilePicture);
                    model.ProfilePictureUrl = profilePictureUrl;

                    await _salonService.CreateSalonAsync(model, userId);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An error occurred while saving the salon.");
                    return View(model);
                }
            }

            return View(model);
        }
    }
}
