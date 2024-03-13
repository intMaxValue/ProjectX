namespace ProjectX.Infrastructure.Data.Models
{
    public class Availability
    {
        public int Id { get; set; }
        // Add properties for availability details (e.g., day, time, etc.)

        public DateTime DateAndTime { get; set; }
        public int SalonId { get; set; } // Foreign key to Salon

        // Navigation property
        public Salon Salon { get; set; } = null!;
    }
}
