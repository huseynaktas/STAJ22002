using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkuTara_Deneme_2.Models.Classes;

namespace OkuTara_Deneme_2.Areas.Admin.Controllers
{
    public class StatisticController : AdminBaseController
    {
        // GET: Admin/Statistic
        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            //Kullanıcı sayısını Count ile alıyoruz ve stringe çeviriyoruz.
            var deger1 = c.Users.Count().ToString();
            ViewBag.d1 = deger1;

            //Toplam qr kod sayısını alıyoruz.
            var deger2 = c.QRCodes.Count().ToString();
            ViewBag.d2 = deger2;

            return View();
        }
    }
}