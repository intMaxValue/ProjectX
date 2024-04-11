using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Controllers
{
    public class ErrorController : Controller
    {
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
