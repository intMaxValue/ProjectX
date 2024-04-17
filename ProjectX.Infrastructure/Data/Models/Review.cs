using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ProjectX.Infrastructure.Constants.DataConstants.Review;

namespace ProjectX.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents a review for a salon.
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Gets or sets the unique identifier of the review.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the salon the review belongs to.
        /// </summary>
        [ForeignKey(nameof(Salon))]
        public int SalonId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who posted the review.
        /// </summary>
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the comment or content of the review.
        /// </summary>
        [StringLength(ReviewMaxLength, MinimumLength = ReviewMinLength, ErrorMessage = ReviewErrorMessage)]
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time when the review was posted.
        /// </summary>
        public DateTime DatePosted { get; set; }

        // Navigation properties

        /// <summary>
        /// Gets or sets the salon associated with the review.
        /// </summary>
        public Salon Salon { get; set; } = null!;

        /// <summary>
        /// Gets or sets the user who posted the review.
        /// </summary>
        public User User { get; set; } = null!;
    }
}
