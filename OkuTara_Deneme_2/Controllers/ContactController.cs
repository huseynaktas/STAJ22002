using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkuTara_Deneme_2.Models.Classes;

namespace OkuTara_Deneme_2.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewContact(Contact contact)
        {
            try
            {
                contact.TimeToSend = DateTime.Now; // Tarihi otomatik olarak ekliyoruz
                c.Contacts.Add(contact);
                c.SaveChanges();

                TempData["Success"] = true; 
            }
            catch
            {
                TempData["Success"] = false;
            }

            return RedirectToAction("NewContact");
        }
    }
}