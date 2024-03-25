using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Contracts;
using ProjectX.ViewModels.Profile;
using System.Security.Claims;

namespace ProjectX.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserProfileService _profileService;

        public UserProfileController(IUserProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            try
            {
                var model = await _profileService.GetProfileAsync(id);
                return View(model);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult CompleteProfile()
        {
            var model = new CompleteProfileViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CompleteProfile(CompleteProfileViewModel model, IFormFile profilePicture)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string currentUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    bool success = await _profileService.UpdateProfileAsync(currentUserId, model, profilePicture);
                    if (success)
                    {
                        return RedirectToAction(nameof(Index), new { id = currentUserId });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to update user profile.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while completing the profile: " + ex.Message);
                }
            }

            return View(model);
        }
    }
}
