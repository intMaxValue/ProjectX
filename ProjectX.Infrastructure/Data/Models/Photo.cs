using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ProjectX.Infrastructure.Constants.DataConstants.Photo;

namespace ProjectX.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents a photo uploaded by a user for a salon.
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// Gets or sets the unique identifier of the photo.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the URL of the photo.
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the caption or description of the photo.
        /// </summary>
        [StringLength(PhotoCaptionMaxLength, MinimumLength = PhotoCaptionMinLength, ErrorMessage = PhotoCaptionErrorMessage)]
        public string Caption { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time when the photo was uploaded.
        /// </summary>
        public DateTime DateUploaded { get; set; }

        /// <summary>
        /// Gets or sets the ID of the salon associated with the photo.
        /// </summary>
        [ForeignKey(nameof(Salon))]
        public int? SalonId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who uploaded the photo.
        /// </summary>
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty;

        // Navigation properties

        /// <summary>
        /// Gets or sets the salon associated with the photo.
        /// </summary>
        public Salon Salon { get; set; } = null!;

        /// <summary>
        /// Gets or sets the user who uploaded the photo.
        /// </summary>
        public User User { get; set; } = null!;
    }
}