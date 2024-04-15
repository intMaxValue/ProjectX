using Microsoft.AspNetCore.Mvc;

namespace ProjectX.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
