using Microsoft.AspNetCore.Identity;
using ProjectX.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace ProjectX.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        [StringLength(DataConstants.User.FirstNameMaxLength, ErrorMessage = DataConstants.User.FirstNameErrorMessage, MinimumLength = DataConstants.User.FirstNameMinLength)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(DataConstants.User.LastNameMaxLength, ErrorMessage = DataConstants.User.LastNameErrorMessage, MinimumLength = DataConstants.User.LastNameMinLength)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(DataConstants.User.CityMaxLength, ErrorMessage = DataConstants.User.CityErrorMessage, MinimumLength = DataConstants.User.CityMinLength)]
        public string City { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<Review> Reviews { get; set; } = null!;
        public ICollection<Photo> Photos { get; set; } = null!;
    }
}
