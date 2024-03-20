using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Contracts;
using ProjectX.ViewModels.Salon;

namespace ProjectX.Controllers
{
    public class SalonProfileController : Controller
    {
        private readonly ISalonService _salonService;

        public SalonProfileController(ISalonService salonService)
        {
            _salonService = salonService;
        }

        public async Task<IActionResult> Index(int id)
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
            };

            return View(model);
        }
    }
}
