using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkuTara_Deneme_2.Models.Classes;
using OkuTara_Deneme_2.ViewModels;

namespace OkuTara_Deneme_2.Areas.Admin.Controllers
{
    public class AdminProfileController : AdminBaseController
    {
        // GET: Admin/AdminProfile
        Context c = new Context();
        public ActionResult Index()
        {
            var mail = (string)Session["UserEmail"]; //Session'da tutulan UserEmail bilgisini alır.
            var degerler = c.Users.FirstOrDefault(x => x.UserEmail == mail); //User tablosundan UserEmail bilgisine göre verileri alır.
            ViewBag.m = mail;

            //Kullanıcının rollerini UserInRole tablosundan çeker. Burada 
            List<Role> userRoles = (from ur in c.UserInRoles
                                    join r in c.Roles on ur.RoleId equals r.RoleId
                                    join u in c.Users on ur.UserId equals u.UserId
                                    where u.UserId == degerler.UserId
                                    select r).ToList();


            var model = new ProfileRoleViewModel
            {
                User = degerler,
                Role = userRoles 
            };

            Session["Username"] = degerler.UserName + " " + degerler.UserSurname;
            return View("Index", model);
        }

        //Kullanıcı bilgilerini getirmek için bir view yapısı
        public ActionResult AdminDetails(int id)
        {
            var user = c.Users.Find(id);
            return View("AdminDetails", user);
        }

        //Kullanıcı bilgilerini güncellemek için bir view yapısı
        public ActionResult AdminUpdate(User user)
        {
            var usr = c.Users.Find(user.UserId);
            usr.UserName = user.UserName;
            usr.UserSurname = user.UserSurname;
            usr.UserPhone = user.UserPhone;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}