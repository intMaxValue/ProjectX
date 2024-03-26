using System.ComponentModel.DataAnnotations;
using ProjectX.Infrastructure.Constants;


namespace ProjectX.ViewModels.Profile
{
    public class CompleteProfileViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(DataConstants.User.FirstNameMaxLength, ErrorMessage = DataConstants.User.FirstNameErrorMessage, MinimumLength = DataConstants.User.FirstNameMinLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(DataConstants.User.LastNameMaxLength, ErrorMessage = DataConstants.User.LastNameErrorMessage, MinimumLength = DataConstants.User.LastNameMinLength)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(DataConstants.User.CityMaxLength, ErrorMessage = DataConstants.User.CityErrorMessage, MinimumLength = DataConstants.User.CityMinLength)]
        public string City { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(DataConstants.User.PhoneNumberMaxLength, ErrorMessage = DataConstants.User.PhoneNumberErrorMessage, MinimumLength = DataConstants.User.PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; } = string.Empty;
    }
}
