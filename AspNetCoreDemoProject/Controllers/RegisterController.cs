using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoProject.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public IActionResult Index(Writer writer)
		{
            writer.WriterStatus = true;
            writer.WriterAbout = "Deneme Test";
            wm.WriterAdd(writer);
            return RedirectToAction("Index", "Blog");
		}
	}
}
