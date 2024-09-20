using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkuTara_Deneme_2.Models.Classes;

namespace OkuTara_Deneme_2.Areas.Admin.Controllers
{
    public class AdminHomeSliderPhotoController : Controller
    {
        // GET: Admin/AdminHomeSliderPhoto
        Context c = new Context();
        public ActionResult Index()
        {
            // Slider fotoğraflarını getir
            var photos = from x in c.HomeSliderPhotos select x; 
            return View(photos.ToList());
        }

        // Slider fotoğraf ekleme sayfası
        [HttpGet]
        public ActionResult AddPhoto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPhoto(HomeSliderPhoto photo, HttpPostedFileBase PhotoAdd)
        {
            if (ModelState.IsValid)
            {
                // Logo Yükleme İşlemi
                if (PhotoAdd != null && PhotoAdd.ContentLength > 0)
                {
                    // Dosya kaydedileceği klasörün yolu
                    var photoDirectory = Server.MapPath("~/Content/SliderPhotos");

                    // Eğer klasör mevcut değilse, oluştur
                    if (!Directory.Exists(photoDirectory))
                    {
                        Directory.CreateDirectory(photoDirectory);
                    }

                    // Dosyanın adı ve tam yolu
                    var photoFileName = Path.GetFileName(PhotoAdd.FileName);
                    var logoPath = Path.Combine(photoDirectory, photoFileName);

                    // Dosyayı hedef dizine kaydet
                    PhotoAdd.SaveAs(logoPath);

                    // Veritabanına kaydedilecek dosya yolu (relative path)
                    photo.PhotoUrl = "/Content/SliderPhotos/" + photoFileName;
                }


                c.HomeSliderPhotos.Add(photo);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photo);
        }

    }
}