using System.ComponentModel.DataAnnotations;
using static ProjectX.Infrastructure.Constants.DataConstants.Review;

namespace ProjectX.ViewModels.Reviews
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public int SalonId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string UserCity { get; set; } = string.Empty;
        public string? UserProfilePictureUrl { get; set; } = string.Empty;

        [Required]
        [StringLength(ReviewMaxLength, MinimumLength = ReviewMinLength, ErrorMessage = ReviewErrorMessage)]
        public string Comment { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }
    }
}
