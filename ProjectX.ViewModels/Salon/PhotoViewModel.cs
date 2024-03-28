using System.ComponentModel.DataAnnotations;

namespace ProjectX.ViewModels.Salon
{
    public class PhotoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The URL is required.")]
        [Display(Name = "Photo URL")]
        public string Url { get; set; } = string.Empty; // This could be a URL or file path

        [Display(Name = "Caption")]
        public string Caption { get; set; } = string.Empty;

        [Display(Name = "Date Uploaded")]
        public DateTime DateUploaded { get; set; }

       
    }
}