namespace ProjectX.ViewModels.Salon
{
    public class SalonIndexViewModel
    {
        public IEnumerable<SalonViewModel> Salons { get; set; } = null!;
        public PaginationInfoViewModel PaginationInfo { get; set; } = null!;
    }
}
