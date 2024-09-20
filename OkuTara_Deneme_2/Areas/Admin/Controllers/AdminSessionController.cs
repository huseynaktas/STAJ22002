using OkuTara_Deneme_2.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YourProjectNamespace.Helpers;

namespace OkuTara_Deneme_2.Areas.Admin.Controllers
{
    public class AdminSessionController : AdminBaseController
    {
        // GET: Admin/AdminSession
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(User p)
        {
            var user = c.Users.FirstOrDefault(x => x.UserEmail == p.UserEmail);

            if (user != null && PasswordHelper.Verify(p.UserPassword, user.UserPassword))
            {
                FormsAuthentication.SetAuthCookie(user.UserEmail, false);
                Session["UserEmail"] = user.UserEmail.ToString(); 
                return RedirectToAction("Index", "AdminHome");
            }
            else
            {
                ViewBag.LoginError = "Geçersiz e-posta veya şifre.";
                return RedirectToAction("AdminLogin", "AdminSession");
            }
        }

        public ActionResult AdminLogOut()
        {
            Session["Username"] = null;

            FormsAuthentication.SignOut(); // Kullanıcı oturumunu sonlandır
            Session.Abandon(); // Tüm session bilgilerini temizle

            return RedirectToAction("AdminLogin", "AdminSession"); // Login sayfasına yönlendir
        }
    }
}