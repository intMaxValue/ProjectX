using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Services;

namespace ProjectX.Controllers
{
    /// <summary>
    /// Controller for managing news-related functionalities, such as displaying news articles and loading more articles.
    /// </summary>
    [Authorize]
    public class NewsController : Controller
    {
        private readonly RssFeedService _rssFeedService;

        public NewsController(RssFeedService rssFeedService)
        {
            _rssFeedService = rssFeedService;
        }

        /// <summary>
        /// Displays a list of news articles from an RSS feed.
        /// </summary>
        /// <returns>The view displaying the list of news articles.</returns>
        public async Task<IActionResult> Index()
        {
            var rssFeedUrl = "https://www.nailsmag.com/rss"; // nailsmag.com RSS feed URL
            var newsItems = await _rssFeedService.GetRssFeedAsync(rssFeedUrl);
            return View(newsItems);
        }

        /// <summary>
        /// Loads more news articles for pagination.
        /// </summary>
        /// <param name="page">The page number to load additional articles for.</param>
        /// <returns>A partial view containing additional news articles.</returns>
        [HttpGet]
        public async Task<IActionResult> LoadMoreArticles(int page)
        {
            int pageSize = 10;
            var newsItems = await _rssFeedService.GetRssFeedAsync("https://www.nailsmag.com/rss", page, pageSize);

            return PartialView("_NewsFeedPartial", newsItems);
        }
    }
}
