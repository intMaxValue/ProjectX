namespace ProjectX.ViewModels.RssNewsFeed
{
    public class NewsItemViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public string Creator { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
