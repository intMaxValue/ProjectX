using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Contracts;
using ProjectX.ViewModels.Salon;

namespace ProjectX.Controllers
{
    public class SalonsController : Controller
    {
        private readonly ISalonService _salonService;

        public SalonsController(ISalonService salonService)
        {
            _salonService = salonService;
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
                MapUrl = s.MapUrl
            });

            return View(salonViewModels);
        }
    }
}
