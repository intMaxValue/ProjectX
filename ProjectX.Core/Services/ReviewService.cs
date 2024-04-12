using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProjectX.Core.Contracts;
using ProjectX.Infrastructure.Data;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Reviews;

namespace ProjectX.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

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

        public async Task<Review?> GetReviewByIdAsync(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

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

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }

        public async Task<string> GetSalonProfilePictureAsync(int salonId)
        {
            var salon = await _context.Salons.FindAsync(salonId);
            return salon?.ProfilePictureUrl ?? string.Empty;
        }
    }
}
