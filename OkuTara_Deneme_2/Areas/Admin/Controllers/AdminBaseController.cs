using OkuTara_Deneme_2.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OkuTara_Deneme_2.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {

        // GET: Admin/AdminBase

        Context c = new Context();
        public ActionResult BaseIndex()
        {
            var currentUser = GetCurrentUser();
            var userRoles = GetUserRoles(currentUser.UserId);

            ViewBag.User = currentUser;
            ViewBag.UserRoles = userRoles;

            return View("~/Areas/Admin/Views/AdminBase/Index.cshtml");
        }

        //public AdminBaseController()
        //{
        //    var currentUser = GetCurrentUser();

        //    if (currentUser != null)
        //    {
        //        var userRoles = GetUserRoles(currentUser.UserId);

        //        if (userRoles == null || (userRoles != null && userRoles.Count() == 0))
        //        {
        //            Response.Redirect("/admin/AdminLogin/....");
        //        }

        //        ViewBag.User = currentUser;

        //        ViewBag.UserRoles = userRoles;

        //    }
        //    else
        //    {
        //        // Response.Redirect("/admin/AdminLogin/....");
        //    }
        //}

        private User GetCurrentUser()
        {
            var userId = Session["UserId"] != null ? Convert.ToInt32(Session["UserId"]) : (int?)null;

            if (!userId.HasValue)
            {
                return null;
            }

            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(u => u.UserId == userId.Value);
            }
        }

        private List<string> GetUserRoles(int userId)
        {
            using (var context = new Context())
            {
                var roles = (from uir in context.UserInRoles 
                             join r in context.Roles on uir.RoleId equals r.RoleId //burada join işlemini kullanarak userinrole tablosundan roleid ile roles tablosundan roleid eşit olanları getiriyoruz
                             where uir.UserId == userId
                             select r.RoleName).ToList();

                return roles;
            }
        }
    }
}