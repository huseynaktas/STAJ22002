using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OkuTara_Deneme_2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Her zaman olana sayfalar
            // Kök URL'yi özelleştirmek için eklenen rota
            routes.MapRoute(
                name: "Root",
                url: "anasayfa",
                defaults: new { controller = "HomeDefault", action = "Index" }
            );

            routes.MapRoute(
                name: "Error",
                url: "Error/{action}",
                defaults: new { controller = "Error", action = "NotFound" }
            );
            //Anasayfa için özel route
            routes.MapRoute(
                name: "HomeDefault",
                url: "ana-sayfa",
                defaults: new { controller = "HomeDefault", action = "Index" }
            );

            // Hakkımızda sayfası için özel route
            routes.MapRoute(
                name: "Hakkimizda",
                url: "hakkimizda",
                defaults: new { controller = "HomeDefault", action = "Hakkimizda" }
            );

            // İletişim sayfası için özel route
            routes.MapRoute(
                name: "Iletisim",
                url: "iletisim",
                defaults: new { controller = "Contact", action = "NewContact" }
            );


            //Giriş yaptıktan sonra kaybolan sayfalar
            //Login sayfası için özel route
            routes.MapRoute(
                name: "Login",
                url: "giris-yap",
                defaults: new { controller = "Login", action = "UserLogin" }
            );

            //Kayıt sayfası için özel route
            routes.MapRoute(
                name: "SignUp",
                url: "kayit-ol",
                defaults: new { controller = "Login", action = "SignUp" }
            );

            //Kayıt sayfasındaki Şartlar ve Koşullar için özel route
            routes.MapRoute(
                name: "",
                url: "sartlar-ve-kosullar",
                defaults: new { controller = "HomeDefault", action = "SartlarVeKosullar" }
            );

            //Giriş yaptıktan sonra gelen sayfalar
            //Profil sayfası için özel route
            routes.MapRoute(
                name: "Profil",
                url: "profil",
                defaults: new { controller = "UserProfile", action = "Index" }
            );

            //Mesajlar sayfası için özel route
            routes.MapRoute(
                name: "Mesajlar",
                url: "mesajlar",
                defaults: new { controller = "UserProfile", action = "Messages" }
            );

            //Çıkış sayfası için özel route
            routes.MapRoute(
                name: "Logout",
                url: "cikis-yap",
                defaults: new { controller = "Login", action = "Logout" }
            );

            //QR İçeriğim Sayfası için özel route
            routes.MapRoute(
                name: "QRContentFetch",
                url: "qr-icerigim",
                defaults: new { controller = "QRContent", action = "QRContentFetch" }
            );

            //QR'lar Sayfası için özel route
            routes.MapRoute(
                name: "QRShow",
                url: "qr-kodlarim",
                defaults: new { controller = "UserProfile", action = "QRShow" }
            );

            //QR'lar sayfasındaki QR oluşturma sayfası için özel route
            routes.MapRoute(
                name: "CreateQR",
                url: "qr-olustur",
                defaults: new { controller = "UserProfile", action = "CreateQR" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "HomeDefault", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
