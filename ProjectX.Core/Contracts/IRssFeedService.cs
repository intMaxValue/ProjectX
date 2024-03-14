using ProjectX.ViewModels.RssNewsFeed;

namespace ProjectX.Core.Contracts
{
    public interface IRssFeedService
    {
        Task<List<NewsItemViewModel>> GetRssFeedAsync(string url, int page, int pageSize);
    }
}
