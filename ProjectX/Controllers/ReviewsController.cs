using Microsoft.AspNetCore.Mvc;
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

            var isSalonOwner = salon.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewData["IsSalonOwner"] = isSalonOwner;

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
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the review.");
                    return Json(new { success = false, error = "An error occurred while creating the review." });
                }
            }
            return Json(new { success = false, error = "Invalid model state." });
        }


        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            try
            {
                // Get the review by id
                var review = await _reviewService.GetReviewByIdAsync(id);

                // Check if the current user is the SalonOwner
                var salon = await _salonService.GetSalonByIdAsync(review.SalonId);
                var isSalonOwner = salon.OwnerId == User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                // Delete the review
                await _reviewService.DeleteReviewAsync(id);

                // Refresh the page
                return RedirectToAction("Index", new { salonId = salon.Id });
            }
            catch (Exception)
            {
                // Log the exception
                return RedirectToAction("Error", "Error"); // Redirect to error page
            }
        }
    }
}
