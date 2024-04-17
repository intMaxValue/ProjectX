using Microsoft.AspNetCore.Identity;
using ProjectX.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace ProjectX.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        [StringLength(DataConstants.User.FirstNameMaxLength, ErrorMessage = DataConstants.User.FirstNameErrorMessage, MinimumLength = DataConstants.User.FirstNameMinLength)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        [StringLength(DataConstants.User.LastNameMaxLength, ErrorMessage = DataConstants.User.LastNameErrorMessage, MinimumLength = DataConstants.User.LastNameMinLength)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the city where the user resides.
        /// </summary>
        [StringLength(DataConstants.User.CityMaxLength, ErrorMessage = DataConstants.User.CityErrorMessage, MinimumLength = DataConstants.User.CityMinLength)]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the profile picture URL of the user.
        /// </summary>
        public string ProfilePicture { get; set; } = string.Empty;

        // Navigation properties

        /// <summary>
        /// Gets or sets the reviews written by the user.
        /// </summary>
        public ICollection<Review> Reviews { get; set; } = null!;

        /// <summary>
        /// Gets or sets the photos uploaded by the user.
        /// </summary>
        public ICollection<Photo> Photos { get; set; } = null!;
    }
}
