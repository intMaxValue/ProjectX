using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectX.Infrastructure.Data.Models
{
    public class Review
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Salon))]
        public int SalonId { get; set; } // Foreign key to Salon

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty; // Foreign key to User
        public string Comment { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }

        // Navigation properties
        public Salon Salon { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
