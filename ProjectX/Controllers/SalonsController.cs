using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Contracts;
using ProjectX.Core.Services;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Salon;

namespace ProjectX.Controllers
{
    /// <summary>
    /// Manages operations related to salons, including listing salons, creating new salons, and viewing salon details.
    /// </summary>
    [Authorize]
    public class SalonsController : Controller
    {
        private readonly ISalonService _salonService;
        private readonly UserManager<User> _userManager;
        private readonly ImageUploader _imageUploader;

        private const int PageSize = 6; // 2 rows * 3 salons per row

        public SalonsController(ISalonService salonService, UserManager<User> userManager, ImageUploader imageUploader)
        {
            _salonService = salonService;
            _userManager = userManager;
            _imageUploader = imageUploader; 
        }

        /// <summary>
        /// Retrieves a paginated list of salons based on the search query and page number.
        /// </summary>
        /// <param name="searchQuery">The search query to filter salons.</param>
        /// <param name="page">The page number for pagination.</param>
        /// <returns>The view displaying the paginated list of salons.</returns>
        public async Task<IActionResult> Index(string searchQuery, int page = 1)
        {
            ViewBag.SearchQuery = searchQuery;

            // Retrieve paginated salons from the service
            var paginatedSalons = await _salonService.GetPaginatedSalonsAsync(searchQuery, page, PageSize);

            // Retrieve total count of salons for pagination
            var totalSalons = await _salonService.GetAllSalonsCountAsync(searchQuery);

            // Calculate total pages
            var totalPages = (int)Math.Ceiling((double)totalSalons / PageSize);

            // Retrieve top 5 cities with salons
            var topCities = await _salonService.GetTopCitiesAsync(5);

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
                },
                TopCities = topCities
            };

            return View(model);
        }

        /// <summary>
        /// Displays the page for creating a new salon.
        /// </summary>
        /// <returns>The view for creating a new salon.</returns>
        public async Task<IActionResult> Create()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            string userId = currentUser.Id;
            ViewBag.UserId = userId;
            return View();
        }

        /// <summary>
        /// Handles the submission of the new salon creation form.
        /// </summary>
        /// <param name="model">The model containing salon information.</param>
        /// <param name="profilePicture">The uploaded profile picture for the salon.</param>
        /// <returns>The result of the salon creation attempt.</returns>
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

                    await _userManager.AddToRoleAsync(currentUser, "SalonOwner");

                    return RedirectToAction("Index", "MySalon", new { area = "" });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "An error occurred while saving the salon.");
                    return View(model);
                }
            }

            return View(model);
        }

        /// <summary>
        /// Displays the details of a specific salon.
        /// </summary>
        /// <param name="id">The ID of the salon to display.</param>
        /// <returns>The view displaying the details of the salon.</returns>
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var salon = await _salonService.GetSalonByIdAsync(id);
            if (salon == null)
            {
                return NotFound();
            }

            var model = new SalonViewModel()
            {
                Id = salon.Id,
                Name = salon.Name,
                City = salon.City,
                Address = salon.Address,
                Description = salon.Description,
                MapUrl = salon.MapUrl,
                PhoneNumber = salon.PhoneNumber,
                ProfilePictureUrl = salon.ProfilePictureUrl,
                Photos = salon.Photos.Select(p => new PhotoViewModel
                {
                    Id = p.Id,
                    Url = p.Url,
                    Caption = p.Caption,
                    DateUploaded = p.DateUploaded
                }).ToList()
            };

            return View(model);
        }
    }
}
