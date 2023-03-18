using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoProject.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = nm.GetList();
            return View(values);
        }
    }
}
