﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(writer);

            if (results.IsValid)
            {
				writer.WriterStatus = true;
				writer.WriterAbout = "Deneme Test";
				wm.TAdd(writer);
				return RedirectToAction("Index", "Blog");
			}
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

            
		}
	}
}
