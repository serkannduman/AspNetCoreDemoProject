﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoProject.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(Writer p)
        {
            Context c = new Context();
            var dataValue = c.Writers.FirstOrDefault(x=> x.WriterMail== p.WriterMail && x.WriterPassword== p.WriterPassword);

            if (dataValue!=null)
            {
                HttpContext.Session.SetString("username", p.WriterMail);
                return RedirectToAction("Index","Writer");
            }

            return View();
        }
    }
}
