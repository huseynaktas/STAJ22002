using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkuTara_Deneme_2.Models.Classes;

namespace OkuTara_Deneme_2.Areas.Admin.Controllers
{
    public class AdminMessageController : AdminBaseController
    {
        // GET: Admin/AdminUserMessage
        Context c = new Context();

        [Authorize]
        public ActionResult Index(string p)
        {
            var messages = from x in c.Contacts select x;
            if (!string.IsNullOrEmpty(p))
            {
                messages = messages.Where(y => y.ContactContent.Contains(p));
            }
            return View(messages.ToList());
        }


        [Authorize]
        public ActionResult ContactDetail(int id)
        {
            var message = c.Contacts.Find(id);
            return View("ContactDetail", message);
        }


        [Authorize]
        public ActionResult ContactUpdate(Contact contact)
        {
            var msg = c.Contacts.Find(contact.ContactId);
            msg.IsRead = contact.IsRead;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}