using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ProjectX.Infrastructure.Constants.DataConstants.Appointment;

namespace ProjectX.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents an appointment made by a SalonOwner for an User.
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// Gets or sets the unique identifier of the appointment.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the appointment.
        /// </summary>
        public DateTime DateAndTime { get; set; }

        /// <summary>
        /// Gets or sets the comment or additional information related to the appointment.
        /// </summary>
        [StringLength(AppointmentCommentMaxLength, MinimumLength = AppointmentCommentMinLength, ErrorMessage = AppointmentErrorMessage)]
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ID of the salon where the appointment is scheduled.
        /// </summary>
        [ForeignKey(nameof(Salon))]
        public int SalonId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who has an appointment.
        /// </summary>
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty;

        // Navigation properties

        /// <summary>
        /// Gets or sets the salon associated with the appointment.
        /// </summary>
        public Salon Salon { get; set; } = null!;

        /// <summary>
        /// Gets or sets the user who made the appointment.
        /// </summary>
        public User User { get; set; } = null!;
    }
}
