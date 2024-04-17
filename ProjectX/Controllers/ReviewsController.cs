using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Contracts;
using ProjectX.ViewModels.Reviews;
using System.Security.Claims;

namespace ProjectX.Controllers
{
    /// <summary>
    /// Controller for managing reviews, including displaying reviews for a specific salon, creating new reviews, and deleting existing reviews.
    /// </summary>
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

        /// <summary>
        /// Displays reviews for a specific salon.
        /// </summary>
        /// <param name="salonId">The ID of the salon to display reviews for.</param>
        /// <returns>The view displaying the reviews for the specified salon.</returns>
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

        /// <summary>
        /// Creates a new review for a salon.
        /// </summary>
        /// <param name="review">The review to be created.</param>
        /// <returns>A JSON response indicating the success or failure of the review creation.</returns>
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


        /// <summary>
        /// Deletes a review with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the review to delete.</param>
        /// <returns>A redirect result to the index action displaying reviews for the associated salon, or an error page if an exception occurs.</returns>
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
