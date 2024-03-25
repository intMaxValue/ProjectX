namespace ProjectX.ViewModels.Salon
{
    public class SalonIndexViewModel
    {
        public IEnumerable<SalonViewModel> Salons { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
