using OkuTara_Deneme_2.Models.Classes;
using OkuTara_Deneme_2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OkuTara_Deneme_2.Controllers
{
    public class QRContentController : BaseController
    {
        // GET: QRContent
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QRContentFetch(int? id)
        {
            //3. deneme
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "User ID is required.");
            }

            var qrContents = c.QRCodeContents.Where(q => q.UserId == id.Value).FirstOrDefault();

            return View("QRContentFetch", qrContents);
        }

        [HttpPost]
        public ActionResult UpdateContent(QRCodeContent p)
        {
            var qr = c.QRCodeContents.Find(p.QRContentId);
            if (qr == null)
            {
                return HttpNotFound("QR Code Content not found.");
            }

            if (ModelState.IsValid)
            {
                qr.GeneralMessage = p.GeneralMessage;
                qr.InstagramUrl = p.InstagramUrl;
                qr.InstagramState = p.InstagramState;
                qr.FacebookUrl = p.FacebookUrl;
                qr.FacebookState = p.FacebookState;
                qr.XUrl = p.XUrl;
                qr.XState = p.XState;
                qr.WhatsappUrl = p.WhatsappUrl;
                qr.WhatsappState = p.WhatsappState;
                c.SaveChanges();
            }
            else
            {
                return View(p);
            }

            
            int userId = qr.UserId;
            return RedirectToAction("QRContentFetch", new { id = userId });
        }

        public ActionResult ShowUser(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "User ID is required.");
            }

            var qrContents = c.QRCodeContents.FirstOrDefault(q => q.UserId == id.Value);

            if (qrContents == null)
            {
                return HttpNotFound("QR Code Content not found.");
            }

            var model = new MessageViewModel
            {
                QRContent = qrContents,
                Message = new Message() // Başlangıçta boş bir mesaj nesnesi
            };

            return View("ShowUser", model);
        }

        [HttpGet]
        public ActionResult SendMessage(int id)
        {
            var qrContent = c.QRCodeContents.FirstOrDefault(q => q.UserId == id);

            if (qrContent == null)
            {
                return HttpNotFound("QR Code Content not found.");
            }

            var model = new MessageViewModel
            {
                QRContent = qrContent,
                Message = new Message()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult SendMessage(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = model.Message;
                message.UserId = model.QRContent.UserId; // Kullanıcının ID'sini ViewModel'den alıyoruz
                message.MessageDate = DateTime.Now;
                c.Messages.Add(message);
                c.SaveChanges();

                TempData["Success"] = true;
                return RedirectToAction("ShowUser", new { id = model.QRContent.UserId });
            }

            // Model geçerli değilse, QRContent'i tekrar yükleyin
            model.QRContent = c.QRCodeContents.FirstOrDefault(q => q.UserId == model.QRContent.UserId);
            return View(model);
        }

        //id kısmını gizlemek için deneme
        public ActionResult SetUserId(int userId)
        {
            Session["UserId"] = userId;
            return RedirectToAction("QRContentFetch");
        }
    }
}
