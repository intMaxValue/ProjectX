using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectX.Infrastructure.Data.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty; // This could be a URL or file path

        [ForeignKey(nameof(Salon))]
        public int? SalonId { get; set; } // Foreign key to Salon

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty; // Foreign key to User

        // Navigation properties
        public Salon Salon { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
