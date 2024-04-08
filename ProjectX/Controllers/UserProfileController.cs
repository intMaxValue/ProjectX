using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Contracts;
using ProjectX.ViewModels.Profile;
using System.Security.Claims;
using ProjectX.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using ProjectX.Infrastructure.Data;

namespace ProjectX.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserProfileService _profileService;
        private readonly UserManager<User> _userManager;

        public UserProfileController(IUserProfileService profileService, UserManager<User> userManager)
        {
            _profileService = profileService;
            _userManager = userManager;
            
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

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            // Retrieve the current user's details
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (currentUser == null)
            {
                return NotFound(); // User not found
            }

            // Map user details to the view model
            var model = new CompleteProfileViewModel
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                City = currentUser.City,
                PhoneNumber = currentUser.PhoneNumber,
                ProfilePictureUrl = currentUser.ProfilePicture
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(CompleteProfileViewModel model, IFormFile profilePicture)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the current user's ID
                    string currentUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                    // Update the user's profile
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

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAppointments()
        {
            string currentUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                var appointments = await _profileService.GetUserAppointmentsAsync(currentUserId);

                return Json(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while fetching appointments: {ex.Message}");
            }
        }

    }
}
