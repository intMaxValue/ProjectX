using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ProjectX.Models;
using System.Diagnostics;
using ProjectX.Infrastructure.Data.Models;

namespace ProjectX.Controllers
{
    /// <summary>
    /// Controller for handling actions related to the home page and error handling.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        /// <summary>
        /// Displays the home page.
        /// </summary>
        /// <returns>The view displaying the home page.</returns>
        [AllowAnonymous] // Allow access to non-logged-in users
        public IActionResult Index()
        {
            // Check if the user is authenticated
            if (User?.Identity?.IsAuthenticated == true)
            {
                // If authenticated, redirect to the NewsController's Index action
                return RedirectToAction("Index", "News");
            }

            return View();
        }

        /// <summary>
        /// Handles errors and displays the error page.
        /// </summary>
        /// <returns>The view displaying the error page.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}