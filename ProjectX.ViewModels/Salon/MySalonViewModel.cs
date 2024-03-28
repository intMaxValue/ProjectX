namespace ProjectX.ViewModels.Salon
{
    public class MySalonViewModel
    {
        public int SalonId { get; set; }
        public string SalonName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string MapUrl { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public List<PhotoViewModel> Photos { get; set; } = new List<PhotoViewModel>();
    }
}