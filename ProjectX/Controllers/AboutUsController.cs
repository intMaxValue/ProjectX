using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
