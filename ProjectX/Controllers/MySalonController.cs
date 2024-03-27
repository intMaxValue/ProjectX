using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Controllers
{
    public class MySalonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
