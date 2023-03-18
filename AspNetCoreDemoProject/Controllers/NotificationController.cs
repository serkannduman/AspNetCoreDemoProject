using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoProject.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
