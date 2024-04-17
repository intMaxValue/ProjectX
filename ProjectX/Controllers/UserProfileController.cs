using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Contracts;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Profile;
using System.Security.Claims;

namespace ProjectX.Controllers
{
    /// <summary>
    /// Manages user profile-related actions such as displaying, completing, and editing profiles, as well as retrieving user appointments.
    /// </summary>
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IUserProfileService _profileService;
        private readonly UserManager<User> _userManager;

        public UserProfileController(IUserProfileService profileService, UserManager<User> userManager)
        {
            _profileService = profileService;
            _userManager = userManager;
            
        }

        /// <summary>
        /// Displays the profile of a user.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The view displaying the user's profile.</returns>
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

        /// <summary>
        /// Displays the complete profile page for a user, if the user hasn't completed his/her profile.
        /// </summary>
        /// <returns>The view displaying the complete profile form.</returns>
        [HttpGet]
        public IActionResult CompleteProfile()
        {
            var model = new CompleteProfileViewModel();
            return View(model);
        }

        /// <summary>
        /// Handles the submission of the complete profile form.
        /// </summary>
        /// <param name="model">The complete profile view model.</param>
        /// <param name="profilePicture">The profile picture uploaded by the user.</param>
        /// <returns>The result of the profile completion attempt.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        /// <summary>
        /// Displays the edit profile page for the current user.
        /// </summary>
        /// <returns>The view displaying the edit profile form.</returns>
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

        /// <summary>
        /// Handles the submission of the edit profile form.
        /// </summary>
        /// <param name="model">The complete profile view model.</param>
        /// <param name="profilePicture">The profile picture uploaded by the user.</param>
        /// <returns>The result of the profile update attempt.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        /// <summary>
        /// Retrieves appointments for the current user.
        /// </summary>
        /// <returns>A JSON representation of the user's appointments.</returns>
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
