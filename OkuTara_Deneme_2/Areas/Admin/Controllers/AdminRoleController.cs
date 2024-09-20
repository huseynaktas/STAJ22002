using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkuTara_Deneme_2.Models.Classes;

namespace OkuTara_Deneme_2.Areas.Admin.Controllers
{
    public class AdminRoleController : AdminBaseController
    {
        // GET: Admin/AdminRole
        Context c = new Context();

        [Authorize]
        public ActionResult Index(string p)
        {
            //var roles = from x in c.Roles select x;
            //if (!string.IsNullOrEmpty(p))
            //{
            //    roles = roles.Where(y => y.RoleName.Contains(p));//
            //}
            //return View(roles.ToList());
            var degerler = c.Roles.Where(x => x.RoleState == true).ToList();
            return View(degerler);
        }

        [Authorize]

        public ActionResult RoleDetails(int id)
        {
            var role = c.Roles.Find(id);
            return View("RoleDetails", role);
        }

        [Authorize]

        public ActionResult RoleUpdate(Role role)
        {
            var rol = c.Roles.Find(role.RoleId);
            rol.RoleName = role.RoleName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize]
        public ActionResult RoleRemove(int id)
        {
            var role = c.Roles.Find(id);
            role.RoleState = false; // Silme işlemi yerine durumunu false yaparak pasif hale getirir.
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize]
        [HttpGet]
        public ActionResult RoleAdd()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult RoleAdd(Role role)
        {
            c.Roles.Add(role);
            var durum = true;
            role.RoleState = durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}