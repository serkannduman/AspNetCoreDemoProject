using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoProject.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity!.Name;
            var writerID = c.Writers.Where(x=>x.WriterMail==userMail).Select(x=>x.WriterID).FirstOrDefault();
            var values = wm.GetWriterByID(writerID);
            return View(values);
        }

    }
}
