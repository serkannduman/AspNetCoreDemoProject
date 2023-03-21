using AspNetCoreDemoProject.Areas.Admin.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int blogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.ID;
                    workSheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
            
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel {ID=1,BlogName="C# Programlamaya Giriş"},
                new BlogModel {ID=2,BlogName="Tesla Firmasının araçları"},
                new BlogModel {ID=3,BlogName="2020 olimpiyatları"},

            };
            return bm;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int blogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.ID;
                    workSheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }

        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bm = new List<BlogModel2>();
            using (var c=new Context())
            {
                bm = c.Blogs.Select(x => new BlogModel2 
                { 
                    ID=x.BlogID,
                    BlogName=x.BlogTitle
                }).ToList();
            }
            return bm;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
