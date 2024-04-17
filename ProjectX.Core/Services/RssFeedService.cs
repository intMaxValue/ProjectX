using System.Xml.Linq;
using ProjectX.Core.Contracts;
using ProjectX.ViewModels.RssNewsFeed;

namespace ProjectX.Core.Services
{
    /// <summary>
    /// Service for retrieving RSS news feed items.
    /// </summary>
    public class RssFeedService : IRssFeedService
    {
        /// <summary>
        /// Retrieves RSS news feed items from the specified URL with pagination.
        /// </summary>
        /// <param name="url">The URL of the RSS feed.</param>
        /// <param name="page">The page number to retrieve (default is 1).</param>
        /// <param name="pageSize">The number of items per page (default is 10).</param>
        /// <returns>A list of <see cref="NewsItemViewModel"/> representing the RSS feed items.</returns>
        public async Task<List<NewsItemViewModel>> GetRssFeedAsync(string url, int page = 1, int pageSize = 10)
        {
            List<NewsItemViewModel> newsItems = new List<NewsItemViewModel>();
            HashSet<string> uniqueUrls = new HashSet<string>();

            using (var client = new HttpClient())
            {
                var stream = await client.GetStreamAsync(url);
                var doc = XDocument.Load(stream);

                XNamespace media = "http://search.yahoo.com/mrss/";

#pragma warning disable CS8601 // Possible null reference assignment.
                var items = doc.Descendants("item").Select(item => new NewsItemViewModel
                    {
                        Title = item.Element("title")?.Value,
                        Link = item.Element("link")?.Value,
                        Description = item.Element("description")?.Value,
                        PublishDate = DateTime.TryParse(item.Element("pubDate")?.Value, out DateTime pubDate) ? pubDate : DateTime.MinValue,
                        Creator = item.Element("{http://purl.org/dc/elements/1.1/}creator")?.Value,
                        ImageUrl = item.Element(media + "content")?.Attribute("url")?.Value // Extract image URL from media:content element
                    })
                    .Where(item => !string.IsNullOrEmpty(item.ImageUrl) && uniqueUrls.Add(item.Link)) // Filter out duplicates based on URL
                    .ToList();
#pragma warning restore CS8601 // Possible null reference assignment.

                // Implement pagination
                // Calculate the range of items to return based on page and pageSize
                int skip = (page - 1) * pageSize;
                var paginatedItems = items.Skip(skip).Take(pageSize).ToList();

                newsItems.AddRange(paginatedItems);
            }

            return newsItems;
        }
    }
}
