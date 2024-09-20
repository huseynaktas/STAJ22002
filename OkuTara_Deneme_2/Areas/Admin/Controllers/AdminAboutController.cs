using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkuTara_Deneme_2.Models.Classes;

namespace OkuTara_Deneme_2.Areas.Admin.Controllers
{
    public class AdminAboutController : Controller
    {
        // GET: Admin/AdminAbout
        Context c = new Context();
        [HttpGet]
        public ActionResult Index()
        {
            // Veritabanından mevcut hakkımızda içeriğini getiriyoruz.
            var aboutContent = c.Abouts.FirstOrDefault();
            return View(aboutContent);
        }

        [HttpPost]
        public ActionResult Index(About about)
        {
            var existingAbout = c.Abouts.FirstOrDefault();
            if (existingAbout != null)
            {
                existingAbout.AboutContent = about.AboutContent;
                c.SaveChanges();  // İçeriği güncelliyoruz.
            }
            else
            {
                c.Abouts.Add(about);
                c.SaveChanges();  // İlk defa ekleniyorsa, yeni içerik olarak kaydediyoruz.
            }

            return RedirectToAction("Index");
        }
    }
}