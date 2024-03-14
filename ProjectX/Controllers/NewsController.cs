using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Services;

namespace ProjectX.Controllers
{
    
    public class NewsController : Controller
    {
        private readonly RssFeedService _rssFeedService;

        public NewsController(RssFeedService rssFeedService)
        {
            _rssFeedService = rssFeedService;
        }

        public async Task<IActionResult> Index()
        {
            var rssFeedUrl = "https://www.nailsmag.com/rss"; // Replace this with your RSS feed URL
            var newsItems = await _rssFeedService.GetRssFeedAsync(rssFeedUrl);
            return View(newsItems);
        }

        [HttpGet]
        public async Task<IActionResult> LoadMoreArticles(int page)
        {
            int pageSize = 10;
            var newsItems = await _rssFeedService.GetRssFeedAsync("https://www.nailsmag.com/rss", page, pageSize);

            return PartialView("_NewsFeedPartial", newsItems);
        }
    }
}
