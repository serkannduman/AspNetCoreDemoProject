using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoProject.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
