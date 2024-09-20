using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkuTara_Deneme_2.Models.Classes;
using OkuTara_Deneme_2.ViewModels;

namespace OkuTara_Deneme_2.Areas.Admin.Controllers
{
    public class AdminUserController : AdminBaseController
    {
        // GET: Admin/AdminUser
        Context c = new Context();

        [Authorize]
        public ActionResult Index(string p)
        {
            //var users = from x in c.Users select x;

            //if (!string.IsNullOrEmpty(p))
            //{
            //    users = users.Where(y => y.UserName.Contains(p));
            //}

            //return View(users.ToList());

            var users = (from x in c.Users select x).ToList();

            List<ListToUserViewModel> viewModel = new List<ListToUserViewModel>();
            foreach (var user in users)
            {
                List<Role> userRoles = (from ur in c.UserInRoles
                                        join r in c.Roles on ur.RoleId equals r.RoleId
                                        join u in c.Users on ur.UserId equals u.UserId
                                        where u.UserId==user.UserId select r).ToList();

                viewModel.Add(new ListToUserViewModel
                {
                    User = user,
                    Roles = userRoles
                });
            }

            return View(viewModel);

            //Kullanıcıları getirme
            //var users = c.Users.ToList();

            //mevcut kullanıcıya ait rolü getirme
            //var roles = c.UserInRoles
            //    .Where(x => x.UserId == users.FirstOrDefault().UserId)
            //    .Join(c.Roles, ur => ur.RoleId, r => r.RoleId, (ur, r) => new
            //    {
            //        RoleId = ur.RoleId,
            //        RoleName = r.RoleName
            //    }).ToList();

            //var model = new ListToUserViewModel
            //{
            //    User = users,
            //    UserInRole = roles.Select(x => new UserInRole
            //    {
            //        RoleId = x.RoleId
            //    }).ToList()
            //};

            //Kullanıcıya ait rolü viewbag ile gönderme
            //ViewBag.RoleName = roles.Select(x => x.RoleName).ToList();

            //return View(model);
        }


        [Authorize]
        public ActionResult Detail(int id)
        {
            var user = c.Users.Find(id);
            return View("Detail", user);
        }


        [Authorize]
        public ActionResult UserUpdate(User user)
        {
            var usr = c.Users.Find(user.UserId);
            usr.UserName = user.UserName;
            usr.UserSurname = user.UserSurname;
            usr.UserPhone = user.UserPhone;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize]
        [HttpGet]
        public ActionResult UserRoleAdd(int id)
        {           
            List<SelectListItem> degerler = (from x in c.Roles
                                             where x.RoleState == true
                                             select new SelectListItem
                                             {
                                                 Text = x.RoleName,
                                                 Value = x.RoleId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            
            var user = c.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            
            var model = new UserInRoleViewModel
            {
                UserInRole = new UserInRole
                {
                    User = user
                    
                }
            };

            model.User = user;

            // View'e ViewModel'i gönder
            return View(model);
        }


        [Authorize]
        [HttpPost]
        public ActionResult UserRoleAdd(UserInRoleViewModel model)
        {
            if (ModelState.IsValid) 
            {
                
                var userRole = new UserInRole
                {
                    UserId = model.User.UserId,
                    RoleId = int.Parse(model.Role.RoleName) 
                };

                
                c.UserInRoles.Add(userRole);
                c.SaveChanges();

                
                return RedirectToAction("Index");
            }

            
            List<SelectListItem> degerler = (from x in c.Roles
                                             where x.RoleState == true
                                             select new SelectListItem
                                             {
                                                 Text = x.RoleName,
                                                 Value = x.RoleId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View(model);
        }
    }
}