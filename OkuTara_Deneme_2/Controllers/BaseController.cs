using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkuTara_Deneme_2.Models.Classes;

namespace OkuTara_Deneme_2.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        Context c = new Context();

        // Tüm sayfalarda geçerli olacak metod
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Giriş yapmış kullanıcıyı bulmamız gerekiyor.
            var currentUser = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            // Sadece aktif olan ayarları alıyoruz
            var activeSetting = c.GeneralSettings.FirstOrDefault(x => x.IsActive);
            if (activeSetting != null)
            {
                // ViewBag aracılığıyla ayarları tüm sayfalara aktar
                ViewBag.Title = activeSetting.Title;
                ViewBag.Description = activeSetting.Description;
                ViewBag.Keywords = activeSetting.Keywords;
                ViewBag.FontSize = activeSetting.FontSize;
                ViewBag.FontColor = activeSetting.FontColor;
                ViewBag.FontFamily = activeSetting.FontFamily;
                ViewBag.BackgroundColor = activeSetting.BackgroundColor;
            }
            base.OnActionExecuting(filterContext);
        }


        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}