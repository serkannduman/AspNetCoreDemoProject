using AspNetCoreDemoProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoProject.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID= 1,
                    UserName="Serkan"
                },
                new UserComment
                {
                    ID= 2,
                    UserName="Anıl"
                },
                new UserComment
                {
                    ID=3,
                    UserName="Ayse"
                }
            };
            return View(commentValues);
        }
    }
}
