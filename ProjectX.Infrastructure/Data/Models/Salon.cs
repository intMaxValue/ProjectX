namespace ProjectX.Infrastructure.Data.Models
{
    public class Salon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string MapUrl { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty; // Foreign key to User
        public string ProfilePictureUrl { get; set; } = string.Empty;

        // Navigation properties
        public User Owner { get; set; } = null!;
        public ICollection<Photo> Photos { get; set; } = null!;
        public ICollection<Review> Reviews { get; set; } = null!;
        public ICollection<Appointment> Appointments { get; set; } = null!;
        public ICollection<Availability> Availabilities { get; set; } = null!;
    }
}
