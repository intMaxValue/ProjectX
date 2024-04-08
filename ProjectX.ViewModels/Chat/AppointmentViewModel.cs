using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectX.ViewModels.Appointment
{
    public class AppointmentViewModel
    {
        [Required] 
        public string UserId { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date and Time")]
        public DateTime DateTime { get; set; }

        [StringLength(500)]
        public string Comment { get; set; } = string.Empty;

        [Required]
        public int SalonId { get; set; } 
        public string SalonName { get; set;} = string.Empty;
    }
}