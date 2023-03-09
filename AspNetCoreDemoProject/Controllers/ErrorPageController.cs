using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1(int code)
        {

            return View();
        }
    }
}
