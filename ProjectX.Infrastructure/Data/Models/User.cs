using Microsoft.AspNetCore.Identity;
using ProjectX.Infrastructure.Data.Models.Enums;

namespace ProjectX.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public UserType UserType { get; set; }
        public string ProfilePicture { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<Review> Reviews { get; set; } = null!;
        public ICollection<Photo> Photos { get; set; } = null!;
    }
}
