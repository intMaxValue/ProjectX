using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.Infrastructure.Data;
using ProjectX.Core.Contracts;
using ProjectX.ViewModels.Reviews;
using System.Security.Claims;

namespace ProjectX.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly ISalonService _salonService;
        private readonly IUserProfileService _userProfileService;

        public ReviewsController(IReviewService reviewService, ISalonService salonService, IUserProfileService userProfileService)
        {
            _reviewService = reviewService;
            _salonService = salonService;
            _userProfileService = userProfileService;
        }

        // GET: Reviews for a specific salon
        [HttpGet("/Salons/{salonId}/Reviews")]
        public async Task<IActionResult> Index(int salonId)
        {
            var salonProfilePictureUrl = await _reviewService.GetSalonProfilePictureAsync(salonId);
            ViewData["SalonProfilePictureUrl"] = salonProfilePictureUrl;

            var salon = await _salonService.GetSalonByIdAsync(salonId);
            ViewData["SalonName"] = salon!.Name;

            ViewData["SalonId"] = salonId;

            // Fetch the user's profile data
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userProfile = await _userProfileService.GetProfileAsync(userId);
            ViewData["UserId"] = userId;
            ViewData["UserProfilePicture"] = userProfile.ProfilePictureUrl;
            ViewData["FullName"] = $"{userProfile.FirstName} {userProfile.LastName}";
            ViewData["City"] = userProfile.City; // Add City to ViewData

            var reviews = await _reviewService.GetReviewsForSalonAsync(salonId);
            return View(reviews);
        }


        // POST: Reviews/Create
        [HttpPost("/Salons/{salonId}/Reviews/CreateAsync")]
        public async Task<IActionResult> CreateAsync(ReviewViewModel review)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _reviewService.CreateReviewAsync(review);
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the review.");
                    return Json(new { success = false, error = "An error occurred while creating the review." });
                }
            }
            return Json(new { success = false, error = "Invalid model state." });
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> EditAsync(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, ReviewViewModel review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _reviewService.UpdateReviewAsync(review);
                    return RedirectToAction("Index", "Salons", new { id = review.SalonId });
                }
                catch (Exception ex)
                {
                    // Log the exception
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the review.");
                    return View(review);
                }
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            try
            {
                await _reviewService.DeleteReviewAsync(id);
                return RedirectToAction("Index", "Salons", new { id });
            }
            catch (Exception ex)
            {
                // Log the exception
                return RedirectToAction("Error", "Home"); // Redirect to error page
            }
        }
    }
}
