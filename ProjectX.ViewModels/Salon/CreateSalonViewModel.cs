using Microsoft.AspNetCore.Http;
using ProjectX.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace ProjectX.ViewModels.Salon
{
    public class CreateSalonViewModel
    {
        [StringLength(DataConstants.Salon.NameMaxLength, ErrorMessage = DataConstants.Salon.NameErrorMessage, MinimumLength = DataConstants.Salon.NameMinLength)]
        public string Name { get; set; } = string.Empty;


        [StringLength(DataConstants.Salon.AddressMaxLength, ErrorMessage = DataConstants.Salon.AddressErrorMessage, MinimumLength = DataConstants.Salon.AddressMinLength)]
        public string Address { get; set; } = string.Empty;


        [StringLength(DataConstants.Salon.CityMaxLength, ErrorMessage = DataConstants.Salon.CityErrorMessage, MinimumLength = DataConstants.Salon.CityMinLength)]
        public string City { get; set; } = string.Empty;


        [StringLength(DataConstants.Salon.PhoneNumberMaxLength, ErrorMessage = DataConstants.Salon.PhoneNumberErrorMessage, MinimumLength = DataConstants.Salon.PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = string.Empty;


        [StringLength(DataConstants.Salon.DescriptionMaxLength, ErrorMessage = DataConstants.Salon.DescriptionErrorMessage, MinimumLength = DataConstants.Salon.DescriptionMinLength)]
        public string Description { get; set; } = string.Empty;
        public string MapUrl { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public IFormFile? NewProfilePicture { get; set; }
    }
}
