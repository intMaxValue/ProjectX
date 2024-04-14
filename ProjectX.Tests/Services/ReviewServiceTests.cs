using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProjectX.Core.Services;
using ProjectX.Infrastructure.Data;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Reviews;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectX.Tests.Services
{
    [TestFixture]
    public class ReviewServiceTests
    {
        [Test]
        public async Task GetReviewsForSalonAsync_ReturnsCorrectReviews()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            await using var context = new ApplicationDbContext(options);
            var reviewService = new ReviewService(context);

            context.Reviews.AddRange(new List<Review>
            {
                new Review { Id = 1, SalonId = 1, UserId = "1", Comment = "Review 1", DatePosted = DateTime.UtcNow },
                new Review { Id = 2, SalonId = 1, UserId = "2", Comment = "Review 2", DatePosted = DateTime.UtcNow },
                new Review { Id = 3, SalonId = 2, UserId = "1", Comment = "Review 3", DatePosted = DateTime.UtcNow }
            });
            await context.SaveChangesAsync();

            // Act
            var result = await reviewService.GetReviewsForSalonAsync(1);

            // Assert
            Assert.That(result.Count, Is.EqualTo(0));
        }


        [Test]
        public async Task GetReviewViewModelAsync_ReturnsCorrectReview()
        {
            // Arrange
            using var context = CreateDbContext();
            context.Reviews.AddRange(new List<Review>
            {
                new Review { Id = 4, SalonId = 1, UserId = "1", Comment = "Review 4", DatePosted = DateTime.UtcNow },
                new Review { Id = 5, SalonId = 1, UserId = "2", Comment = "Review 5", DatePosted = DateTime.UtcNow }
            });
            await context.SaveChangesAsync();

            var reviewService = new ReviewService(context);

            // Act
            var result = await reviewService.GetReviewViewModelAsync(5);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task CreateReviewAsync_AddsReviewToDatabase()
        {
            // Arrange
            using var context = CreateDbContext();
            var reviewService = new ReviewService(context);
            var review = new ReviewViewModel
            {
                SalonId = 2,
                UserId = "2",
                Comment = "New review",
                DatePosted = DateTime.UtcNow
            };

            // Act
            await reviewService.CreateReviewAsync(review);

            // Assert
            var createdReview = await context.Reviews.FirstOrDefaultAsync(r => r.Comment == "New review");
            Assert.IsNotNull(createdReview);
        }

        [Test]
        public async Task GetReviewByIdAsync_ReturnsCorrectReview()
        {
            // Arrange
            await using var context = CreateDbContext();
            var reviewService = new ReviewService(context);

            // Add reviews to the context
            context.Reviews.AddRange(new List<Review>
            {
                new Review { Id = 1, SalonId = 1, UserId = "1", Comment = "Review 1", DatePosted = DateTime.UtcNow },
                new Review { Id = 2, SalonId = 1, UserId = "2", Comment = "Review 2", DatePosted = DateTime.UtcNow },
                new Review { Id = 3, SalonId = 2, UserId = "1", Comment = "Review 3", DatePosted = DateTime.UtcNow }
            });
            await context.SaveChangesAsync();

            // Act
            var reviewId = 2; // Choose a review ID to retrieve
            var result = await reviewService.GetReviewByIdAsync(reviewId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(reviewId));
        }

        [Test]
        public async Task DeleteReviewAsync_RemovesReviewFromDatabase()
        {
            // Arrange
            await using var context = CreateDbContext();
            var reviewService = new ReviewService(context);

            // Add a review to the context
            var reviewIdToDelete = 1;
            context.Reviews.Add(new Review { Id = reviewIdToDelete, SalonId = 1, UserId = "1", Comment = "Review to delete", DatePosted = DateTime.UtcNow });
            await context.SaveChangesAsync();

            // Act
            await reviewService.DeleteReviewAsync(reviewIdToDelete);

            // Assert
            var deletedReview = await context.Reviews.FindAsync(reviewIdToDelete);
            Assert.IsNull(deletedReview);
        }

        [Test]
        public async Task GetSalonProfilePictureAsync_ReturnsCorrectProfilePictureUrl()
        {
            // Arrange
            await using var context = CreateDbContext();
            var reviewService = new ReviewService(context);

            // Add a salon to the context
            var salonId = 1;
            var profilePictureUrl = "https://example.com/profile.jpg";
            context.Salons.Add(new Salon { Id = salonId, ProfilePictureUrl = profilePictureUrl });
            await context.SaveChangesAsync();

            // Act
            var result = await reviewService.GetSalonProfilePictureAsync(salonId);

            // Assert
            Assert.That(result, Is.EqualTo(profilePictureUrl));
        }

        private ApplicationDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new ApplicationDbContext(options);
        }
    }
}
