using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoProject.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
