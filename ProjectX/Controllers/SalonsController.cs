using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectX.Core.Contracts;
using ProjectX.Core.Services;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Salon;

namespace ProjectX.Controllers
{
    public class SalonsController : Controller
    {
        private readonly ISalonService _salonService;
        private readonly UserManager<User> _userManager;
        private readonly ImageUploader _imageUploader;

        private const int PageSize = 3; // 2 rows * 3 salons per row

        public SalonsController(ISalonService salonService, UserManager<User> userManager, ImageUploader imageUploader)
        {
            _salonService = salonService;
            _userManager = userManager;
            _imageUploader = imageUploader; 
        }

        public async Task<IActionResult> Index(string searchQuery, int page = 1)
        {
            ViewBag.SearchQuery = searchQuery;

            // Retrieve paginated salons from the service
            var paginatedSalons = await _salonService.GetPaginatedSalonsAsync(searchQuery, page, PageSize);

            // Retrieve total count of salons for pagination
            var totalSalons = await _salonService.GetAllSalonsCountAsync(searchQuery);

            // Calculate total pages
            var totalPages = (int)Math.Ceiling((double)totalSalons / PageSize);

            var model = new SalonIndexViewModel
            {
                Salons = paginatedSalons.Select(s => new SalonViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    City = s.City,
                    PhoneNumber = s.PhoneNumber,
                    Description = s.Description,
                    MapUrl = s.MapUrl,
                    ProfilePictureUrl = s.ProfilePictureUrl,
                }),
                PaginationInfo = new PaginationInfoViewModel
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = totalSalons,
                    TotalPages = totalPages
                }
            };

            return View(model);
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
