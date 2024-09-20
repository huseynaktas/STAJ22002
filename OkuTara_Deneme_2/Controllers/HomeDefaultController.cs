using OkuTara_Deneme_2.Models.Classes;
using OkuTara_Deneme_2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OkuTara_Deneme_2.Controllers
{
    public class HomeDefaultController : BaseController
    {
        Context c = new Context();

        // GET: HomeDefault
        public ActionResult Index()
        {
            //Slider fotoğraflarını getir
            var photos = from x in c.HomeSliderPhotos select x;

            //Burada Anasayfa1 yerine AdminPages.Section1 yazılmalı
            ViewBag.PagesSection1 = c.Pages.Where(x => x.Section == AdminPages.Section1);
            ViewBag.PagesSection2 = c.Pages.Where(x => x.Section == AdminPages.Section2);
            ViewBag.PagesSection3 = c.Pages.Where(x => x.Section == AdminPages.Section3);
            ViewBag.PagesSection4 = c.Pages.Where(x => x.Section == AdminPages.Section4);
            ViewBag.PagesSection5 = c.Pages.Where(x => x.Section == AdminPages.Section5);
            ViewBag.PagesSection6 = c.Pages.Where(x => x.Section == AdminPages.Section6);
            ViewBag.PagesSection7 = c.Pages.Where(x => x.Section == AdminPages.Section7);

            return View(photos.ToList());
        }

        public ActionResult Hakkimizda()
        {
            //var employees = c.Employees.ToList();
            //return View(employees);
            var employees = c.Employees.ToList();
            var aboutContent = c.Abouts.FirstOrDefault(); // Veritabanından Hakkımızda içeriği çekiliyor

            var viewModel = new AboutUsViewModel
            {
                Employees = employees,
                AboutContent = aboutContent
            };

            return View(viewModel);

        }

        public ActionResult SartlarVeKosullar()
        {
            return View();
        }

        public ActionResult CauseError()
        {
            //try
            //{
            //    string str = null;

            //    int length = str.Length; // Burada hata oluşacak

            //}
            //catch (Exception ex)
            //{
            //    // return RedirectToAction("InternalServer", "Error");
            //}

            string str = null;

            int length = str.Length; // Burada hata oluşacak


            // Bu kod bilinçli olarak bir NullReferenceException oluşturur

            return View();
        }
    }
}