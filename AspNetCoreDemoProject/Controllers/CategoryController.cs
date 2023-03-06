using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoProject.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
