using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProjectX.Core.Contracts;
using ProjectX.Infrastructure.Data;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Reviews;

namespace ProjectX.Core.Services
{
    /// <summary>
    /// Service for managing reviews.
    /// </summary>
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all reviews for a salon asynchronously.
        /// </summary>
        /// <param name="salonId">The ID of the salon.</param>
        /// <returns>A list of <see cref="ReviewViewModel"/> representing the reviews.</returns>
        public async Task<IList<ReviewViewModel>> GetReviewsForSalonAsync(int salonId)
        {
            var reviews = await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Salon)
                .Where(r => r.SalonId == salonId)
                .ToListAsync();

            var reviewViewModels = reviews.Select(r => new ReviewViewModel
            {
                Id = r.Id,
                SalonId = r.SalonId,
                UserId = r.UserId,
                FullName = $"{r.User.FirstName} {r.User.LastName}",
                UserCity = r.User.City,
                UserProfilePictureUrl = r.User.ProfilePicture,
                Comment = r.Comment,
                DatePosted = r.DatePosted
            }).ToList();

            return reviewViewModels;
        }

        /// <summary>
        /// Retrieves a review view model by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the review.</param>
        /// <returns>A <see cref="ReviewViewModel"/> representing the review.</returns>
        public async Task<ReviewViewModel> GetReviewViewModelAsync(int id)
        {
            var review = await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Salon)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (review == null)
            {
                return null;
            }

            return new ReviewViewModel
            {
                Id = review.Id,
                SalonId = review.SalonId,
                UserId = review.UserId,
                FullName = $"{review.User.FirstName} {review.User.LastName}",
                UserCity = review.User.City,
                UserProfilePictureUrl = review.User.ProfilePicture,
                Comment = review.Comment,
                DatePosted = review.DatePosted,
            };
        }

        /// <summary>
        /// Creates a new review asynchronously.
        /// </summary>
        /// <param name="review">The review to create.</param>
        public async Task CreateReviewAsync(ReviewViewModel review)
        {
            var newReview = new Review
            {
                SalonId = review.SalonId,
                UserId = review.UserId,
                Comment = review.Comment,
                DatePosted = DateTime.UtcNow
            };

            _context.Add(newReview);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a review by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the review.</param>
        /// <returns>A <see cref="Review"/> representing the review.</returns>
        public async Task<Review?> GetReviewByIdAsync(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        /// <summary>
        /// Updates an existing review asynchronously.
        /// </summary>
        /// <param name="review">The review to update.</param>
        public async Task UpdateReviewAsync(ReviewViewModel review)
        {
            var existingReview = await _context.Reviews.FindAsync(review.Id);
            if (existingReview == null)
            {
                throw new Exception("Review not found.");
            }

            existingReview.SalonId = review.SalonId;
            existingReview.UserId = review.UserId;
            existingReview.Comment = review.Comment;

            _context.Update(existingReview);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a review by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the review to delete.</param>
        public async Task DeleteReviewAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves the profile picture URL of a salon asynchronously.
        /// </summary>
        /// <param name="salonId">The ID of the salon.</param>
        /// <returns>The profile picture URL of the salon.</returns>
        public async Task<string> GetSalonProfilePictureAsync(int salonId)
        {
            var salon = await _context.Salons.FindAsync(salonId);
            return salon?.ProfilePictureUrl ?? string.Empty;
        }
    }
}
