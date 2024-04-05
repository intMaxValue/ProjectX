using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ProjectX.Infrastructure.Constants.DataConstants.Photo;

namespace ProjectX.Infrastructure.Data.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;

        [StringLength(PhotoCaptionMaxLength, MinimumLength = PhotoCaptionMinLength, ErrorMessage = PhotoCaptionErrorMessage)]
        public string Caption { get; set; } = string.Empty;
        public DateTime DateUploaded { get; set; }

        [ForeignKey(nameof(Salon))]
        public int? SalonId { get; set; } // Foreign key to Salon

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty; // Foreign key to User

        // Navigation properties
        public Salon Salon { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}