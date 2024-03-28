using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Contracts;
using ProjectX.ViewModels.Salon;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectX.Controllers
{
    public class MySalonController : Controller
    {
        private readonly ISalonService _salonService;

        public MySalonController(ISalonService salonService)
        {
            _salonService = salonService;
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
                PhotoUrls = s.Photos.Select(p => p.Url)
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
                PhotoUrls = salon.Photos.Select(p => p.Url)
            };

            // Return a partial view with the salon details
            return PartialView("_SalonDetailsPartial", viewModel);
        }

    }
}
