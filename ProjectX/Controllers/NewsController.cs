using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
