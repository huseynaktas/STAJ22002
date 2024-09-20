using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OkuTara_Deneme_2.Models.Classes;
using QRCoder;

namespace OkuTara_Deneme_2.Controllers
{
    public class UserProfileController : BaseController
    {
        // GET: UserProfile
        Context c = new Context();
        [Authorize] //Bu kısım sadece giriş yapmış kullanıcıların görebileceği sayfaları belirlemek için kullanılır.
        public ActionResult Index()
        {
            var mail = (string)Session["UserEmail"]; //Session'da tutulan UserEmail bilgisini alır.
            var degerler = c.Users.FirstOrDefault(x => x.UserEmail == mail); //User tablosundan UserEmail bilgisine göre verileri alır.
            ViewBag.m = mail;
            Session["Username"] = degerler.UserName + " " + degerler.UserSurname;
            //Session["UserID"] = degerler.UserId;
            return View(degerler);
        }


        public ActionResult QRShow(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Kullanıcının QR kodlarını getir
            var qrCodes = c.QRCodes.Where(x => x.UserId == id).ToList();

            if (qrCodes != null && qrCodes.Any())
            {
                ViewBag.QRCodes = qrCodes;
            }
            else
            {
                ViewBag.QRCodes = new List<QRCode>();
            }

            ViewBag.QRCodeCount = qrCodes.Count; // QR kodlarının sayısını ViewBag'e ekle

            return View();
        }

        [Authorize]
        public ActionResult Messages()
        {
            // Kullanıcının email adresini session'dan alıyoruz
            var email = (string)Session["UserEmail"];

            if (string.IsNullOrEmpty(email))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Kullanıcı oturumu bulunamadı.");
            }

            // Kullanıcıyı email adresine göre buluyoruz
            var user = c.Users.FirstOrDefault(x => x.UserEmail == email);

            if (user == null)
            {
                return HttpNotFound("Kullanıcı bulunamadı.");
            }

            // Kullanıcının ID'sini alıyoruz
            int userId = user.UserId;

            // Kullanıcının mesajlarını veritabanından çekiyoruz
            var messages = c.Messages.Where(m => m.UserId == userId).ToList();

            // Mesajları View'e gönderiyoruz
            return View(messages);
        }

        [HttpGet]
        public ActionResult CreateQR()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateQR(string kod)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator kodUret = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = kodUret.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap resim = karekod.GetGraphic(10))
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.karekodImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult SaveQR()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveQR(string qrData)
        {
            // Kullanıcının email adresini session'dan alıyoruz
            var email = (string)Session["UserEmail"];

            if (string.IsNullOrEmpty(email))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Kullanıcı oturumu bulunamadı.");
            }

            // Kullanıcıyı email adresine göre buluyoruz
            var user = c.Users.FirstOrDefault(x => x.UserEmail == email);

            if (user == null)
            {
                return HttpNotFound("Kullanıcı bulunamadı.");
            }

            // QR kod verisini ve tarihini kaydetme
            QRCode yeniQRCode = new QRCode
            {
                QRCodeData = qrData,
                QRCodeDate = DateTime.Now,
                UserId = user.UserId
            };

            // Veritabanına kaydetme işlemi
            c.QRCodes.Add(yeniQRCode);
            //c.SaveChanges();

            // Başarı mesajını TempData yerine ViewBag ile gönder
            //TempData["SuccessMessage"] = "QR kodunuz başarıyla kaydedildi!";

            bool isSavedSuccessfully = c.SaveChanges() > 0;

            if (isSavedSuccessfully)
            {
                // Başarı mesajını TempData ile gönder
                TempData["SuccessMessage"] = "QR kodunuz başarıyla kaydedildi!";
            }
            else
            {
                // Hata mesajını TempData ile gönder
                TempData["ErrorMessage"] = "QR kodu kaydedilirken bir hata oluştu.";
            }

            return RedirectToAction("CreateQR", new { id = user.UserId });
        }

        
    }
}