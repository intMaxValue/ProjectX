using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectX.Infrastructure.Data.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        // Add properties for appointment details (e.g., date, time, service, etc.)

        public DateTime DateAndTime { get; set; }

        [ForeignKey(nameof(Salon))]
        public int SalonId { get; set; } // Foreign key to Salon

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty; // Foreign key to User

        // Navigation properties
        public Salon Salon { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
