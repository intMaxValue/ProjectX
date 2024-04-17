using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Contracts;
using ProjectX.Core.Services;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Salon;

namespace ProjectX.Areas.Admin.Controllers
{
    /// <summary>
    /// Controller for managing salon-related operations in the admin area.
    /// </summary>
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SalonsController : Controller
    {
        private readonly ISalonService _salonService;
        private readonly UserManager<User> _userManager;
        private readonly ImageUploader _imageUploader;

        private const int PageSize = 10; // 2 rows * 3 salons per row

        public SalonsController(ISalonService salonService, UserManager<User> userManager, ImageUploader imageUploader)
        {
            _salonService = salonService;
            _userManager = userManager;
            _imageUploader = imageUploader;
        }

        /// <summary>
        /// Displays a paginated list of salons with the option to search.
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

        /// <summary>
        /// Displays the details of a salon.
        /// </summary>
        /// <param name="id">The ID of the salon.</param>
        /// <returns>The view displaying the salon details.</returns>
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

            ViewBag.OwnerId = salon.OwnerId;
            

            return View(model);
        }

        /// <summary>
        /// Deletes a salon with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the salon to delete.</param>
        /// <returns>A redirection to the index action after deletion.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _salonService.DeleteSalonAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
