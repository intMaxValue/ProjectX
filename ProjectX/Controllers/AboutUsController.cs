using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Controllers
{
    /// <summary>
    /// Controller for managing the About Us page.
    /// </summary>
    public class AboutUsController : Controller
    {
        /// <summary>
        /// Displays the About Us page.
        /// </summary>
        /// <returns>The view displaying the About Us page.</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
