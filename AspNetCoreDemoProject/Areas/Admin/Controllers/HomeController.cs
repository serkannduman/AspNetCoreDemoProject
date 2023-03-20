using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoProject.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
