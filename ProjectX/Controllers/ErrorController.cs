using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Controllers
{
    /// <summary>
    /// Controller for handling error pages.
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// Handles HTTP error responses and displays the corresponding error page.
        /// </summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <returns>The view displaying the error page.</returns>
        [HttpGet("/Error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return View("404NotFound");
                case 500:
                    return View("500InternalServerError");
                default:
                    return View("404NotFound");
            }
        }
    }
}
