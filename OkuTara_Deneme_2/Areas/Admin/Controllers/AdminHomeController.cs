using OkuTara_Deneme_2.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OkuTara_Deneme_2.Areas.Admin.Controllers
{
    public class AdminHomeController : AdminBaseController
    {
        // GET: Admin/AdminHome,
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

            //Contact tablosubdaki okunmamış mesaj sayısını alıyoruz.
            var deger3 = c.Contacts.Where(x => x.IsRead == false).Count().ToString();
            ViewBag.d3 = deger3;

            //Contact tablosundaki okunmuş mesaj sayısını alıyoruz.
            var deger4 = c.Contacts.Where(x => x.IsRead == true).Count().ToString();
            ViewBag.d4 = deger4;

            // QR kod sayıları için sorgu
            // QR kod sayıları için sorgu
            var userQRCounts = from user in c.Users
                               join qr in c.QRCodes on user.UserId equals qr.UserId into userQRGroup
                               select new
                               {
                                   Username = user.UserName,
                                   QRCount = userQRGroup.Count()
                               };

            // Konuya göre mesaj sayısı için sorgu
            var subjectCounts = c.Contacts
                                  .GroupBy(m => m.Subject)
                                  .Select(g => new
                                  {
                                      Subject = g.Key,
                                      MessageCount = g.Count()
                                  })
                                  .OrderByDescending(x => x.MessageCount)
                                  .ToList();

            // Verileri ViewBag ile View'a gönderme
            ViewBag.Usernames = userQRCounts.Select(u => u.Username).ToList();
            ViewBag.QRCounts = userQRCounts.Select(u => u.QRCount).ToList();

            ViewBag.Subjects = subjectCounts.Select(s => s.Subject).ToList();
            ViewBag.SubjectCounts = subjectCounts.Select(s => s.MessageCount).ToList();

            return View();

        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult TermsAndConditions()
        {
            return View();
        }
    }
}