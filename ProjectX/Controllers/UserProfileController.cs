using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Contracts;
using ProjectX.Core.Services;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Profile;

namespace ProjectX.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ImageUploader _imageUploader;

        public UserProfileController(UserManager<User> userManager, ImageUploader imageUploader)
        {
            _userManager = userManager;
            _imageUploader = imageUploader;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var model = new CompleteProfileViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.City,
                PhoneNumber = user.PhoneNumber,
                ProfilePictureUrl = user.ProfilePicture
            };

            return View(model);
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
                    // Get the current user
                    var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                    var currentUserId = currentUser.Id;

                    if (currentUser == null)
                    {
                        ModelState.AddModelError("", "User not found.");
                        return View(model);
                    }

                    // Update user profile
                    currentUser.FirstName = model.FirstName;
                    currentUser.LastName = model.LastName;
                    currentUser.PhoneNumber = model.PhoneNumber;
                    currentUser.City = model.City;

                    // Upload profile picture if provided
                    if (profilePicture != null)
                    {
                        string profilePictureUrl = await _imageUploader.UploadImageAsync(profilePicture);
                        currentUser.ProfilePicture = profilePictureUrl;
                    }

                    // Save changes to user profile
                    var result = await _userManager.UpdateAsync(currentUser);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", "Failed to update user profile.");
                        return View(model);
                    }

                    // Redirect to profile confirmation page
                    return RedirectToAction("Index", "UserProfile", $"{currentUserId}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while completing the profile: " + ex.Message);
                    return View(model);
                }
            }

            // If the model state is invalid, redisplay the form with validation errors
            return View(model);
        }

        //public IActionResult ProfileConfirmation()
        //{
        //    return View();
        //}
    }
}
