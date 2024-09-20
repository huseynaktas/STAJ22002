using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkuTara_Deneme_2.Models.Classes;

namespace OkuTara_Deneme_2.Areas.Admin.Controllers
{
    public class AdminGeneralSettingsController : Controller
    {
        // GET: Admin/AdminGeneralSettings
        Context c = new Context();
        public ActionResult Index()
        {
            var settings = c.GeneralSettings.ToList();
            return View(settings);
        }




        // GET: Admin/AdminGeneralSettings/Edit/5
        public ActionResult Edit(int id)
        {
            // Veritabanından ilgili ayarı bul
            var setting = c.GeneralSettings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        // POST: Admin/AdminGeneralSettings/Edit/5
        [HttpPost]
        public ActionResult Edit(GeneralSetting setting, HttpPostedFileBase LogoUpload)
        {
            if (ModelState.IsValid)
            {
                var allSettings = c.GeneralSettings.ToList();
                var updateSetting = c.GeneralSettings.Find(setting.Id);

                foreach (var s in allSettings)
                {
                    if (s.Id != setting.Id)
                    {
                        s.IsActive = false;
                        //c.Entry(s).State = EntityState.Modified;
                    }
                }

                var selectedSetting = c.GeneralSettings.Find(setting.Id);
                if (selectedSetting != null)
                {
                    // Logo Yükleme İşlemi
                    if (LogoUpload != null && LogoUpload.ContentLength > 0)
                    {
                        // Dosya kaydedileceği klasörün yolu
                        var logoDirectory = Server.MapPath("~/Content/Logos");

                        // Eğer klasör mevcut değilse, oluştur
                        if (!Directory.Exists(logoDirectory))
                        {
                            Directory.CreateDirectory(logoDirectory);
                        }

                        // Dosyanın adı ve tam yolu
                        var logoFileName = Path.GetFileName(LogoUpload.FileName);
                        var logoPath = Path.Combine(logoDirectory, logoFileName);

                        // Dosyayı hedef dizine kaydet
                        LogoUpload.SaveAs(logoPath);

                        // Veritabanına kaydedilecek dosya yolu (relative path)
                        selectedSetting.LogoUrl = "/Content/Logos/" + logoFileName;
                    }

                    selectedSetting.IsActive = setting.IsActive; 
                    //c.Entry(selectedSetting).State = EntityState.Modified;
                }

                updateSetting.Title = setting.Title;
                updateSetting.Description = setting.Description;
                updateSetting.Keywords = setting.Keywords;
                updateSetting.FontSize = setting.FontSize;
                updateSetting.FontColor = setting.FontColor;
                updateSetting.FontFamily = setting.FontFamily;
                updateSetting.BackgroundColor = setting.BackgroundColor;
                c.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(setting);
        }




        // Get: Admin/AdminGeneralSettings/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminGeneralSettings/Create
        [HttpPost]
        public ActionResult Create(GeneralSetting setting, HttpPostedFileBase LogoUpload)
        {
            if (ModelState.IsValid)
            {
                // Logo Yükleme İşlemi
                if (LogoUpload != null && LogoUpload.ContentLength > 0)
                {
                    // Dosya kaydedileceği klasörün yolu
                    var logoDirectory = Server.MapPath("~/Content/Logos");

                    // Eğer klasör mevcut değilse, oluştur
                    if (!Directory.Exists(logoDirectory))
                    {
                        Directory.CreateDirectory(logoDirectory);
                    }

                    // Dosyanın adı ve tam yolu
                    var logoFileName = Path.GetFileName(LogoUpload.FileName);
                    var logoPath = Path.Combine(logoDirectory, logoFileName);

                    // Dosyayı hedef dizine kaydet
                    LogoUpload.SaveAs(logoPath);

                    // Veritabanına kaydedilecek dosya yolu (relative path)
                    setting.LogoUrl = "/Content/Logos/" + logoFileName;
                }


                c.GeneralSettings.Add(setting);
                var state = false;
                setting.IsActive = state;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setting);
        }
    }
}