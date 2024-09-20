using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkuTara_Deneme_2.Models.Classes;

namespace OkuTara_Deneme_2.Areas.Admin.Controllers
{
    public class AdminPagesController : AdminBaseController
    {
        // GET: Admin/AdminPages
        Context c = new Context();

        [Authorize]
        public ActionResult Index(string p)
        {
            return View();

        }

        public ActionResult HomePageContent(string p)
        {
            // Anasayfa içeriklerini getir
            var pages = from x in c.Pages select x;
            if (!string.IsNullOrEmpty(p))
            {
                pages = pages.Where(y => y.PageName.Contains(p));
            }
            return View(pages.ToList());
        }

        [Authorize]
        public ActionResult PageDetails(int id)
        {
            var pages = c.Pages.Find(id);
            return View("PageDetails", pages);
        }


        [Authorize]
        public ActionResult PageUpdate(Page page, HttpPostedFileBase PhotoUpload)
        {
            if (ModelState.IsValid)
            {
                if (PhotoUpload != null && PhotoUpload.ContentLength > 0)
                {
                    // Dosya kaydedileceği klasörün yolu
                    var photoDirectory = Server.MapPath("~/Content/PagePhoto");

                    // Eğer klasör mevcut değilse, oluştur
                    if (!Directory.Exists(photoDirectory))
                    {
                        Directory.CreateDirectory(photoDirectory);
                    }

                    // Dosyanın adı ve tam yolu
                    var photoFileName = Path.GetFileName(PhotoUpload.FileName);
                    var photoPath = Path.Combine(photoDirectory, photoFileName);

                    // Dosyayı hedef dizine kaydet
                    PhotoUpload.SaveAs(photoPath);

                    // Veritabanına kaydedilecek dosya yolu (relative path)
                    page.PagePhoto = "/Content/PagePhoto/" + photoFileName;
                }

            }
            // Logo Yükleme İşlemi
            var pgs = c.Pages.Find(page.PageId);
            pgs.PageTitle = page.PageTitle;
            pgs.PageContent = page.PageContent;
            pgs.PagePhoto = page.PagePhoto;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}