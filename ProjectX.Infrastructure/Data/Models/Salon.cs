using ProjectX.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace ProjectX.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents a Nails Salon in the system.
    /// </summary>
    public class Salon
    {
        /// <summary>
        /// Gets or sets the unique identifier of the salon.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the salon.
        /// </summary>
        [StringLength(DataConstants.Salon.NameMaxLength, ErrorMessage = DataConstants.Salon.NameErrorMessage, MinimumLength = DataConstants.Salon.NameMinLength)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the address of the salon.
        /// </summary>
        [StringLength(DataConstants.Salon.AddressMaxLength, ErrorMessage = DataConstants.Salon.AddressErrorMessage, MinimumLength = DataConstants.Salon.AddressMinLength)]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the city where the salon is located.
        /// </summary>
        [StringLength(DataConstants.Salon.CityMaxLength, ErrorMessage = DataConstants.Salon.CityErrorMessage, MinimumLength = DataConstants.Salon.CityMinLength)]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the salon.
        /// </summary>
        [StringLength(DataConstants.Salon.PhoneNumberMaxLength, ErrorMessage = DataConstants.Salon.PhoneNumberErrorMessage, MinimumLength = DataConstants.Salon.PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the salon.
        /// </summary>
        [StringLength(DataConstants.Salon.DescriptionMaxLength, ErrorMessage = DataConstants.Salon.DescriptionErrorMessage, MinimumLength = DataConstants.Salon.DescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the embedded URL of the salon's location on a map.
        /// </summary>
        public string MapUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ID of the owner of the salon.
        /// </summary>
        public string OwnerId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the URL of the salon's profile picture.
        /// </summary>
        public string ProfilePictureUrl { get; set; } = string.Empty;

        // Navigation properties

        /// <summary>
        /// Gets or sets the owner of the salon.
        /// </summary>
        public User Owner { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of photos associated with the salon.
        /// </summary>
        public ICollection<Photo> Photos { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of reviews associated with the salon.
        /// </summary>
        public ICollection<Review> Reviews { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of appointments associated with the salon.
        /// </summary>
        public ICollection<Appointment> Appointments { get; set; } = null!;
    }
}
