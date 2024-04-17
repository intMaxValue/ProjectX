using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Areas.Admin.Controllers
{
    /// <summary>
    /// Controller for managing the Starter Page in the admin area.
    /// </summary>
    public class HomeController : AdminController
    {
        /// <summary>
        /// Displays the Starter Page for the admin area.
        /// </summary>
        /// <returns>The view displaying the home page.</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
