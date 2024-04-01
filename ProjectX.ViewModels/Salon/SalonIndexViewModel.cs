namespace ProjectX.ViewModels.Salon
{
    public class SalonIndexViewModel
    {
        public IEnumerable<SalonViewModel> Salons { get; set; } = null!;
        public PaginationInfoViewModel PaginationInfo { get; set; } = null!;
        public IEnumerable<string> TopCities { get; set; } = new List<string>();
    }
}
