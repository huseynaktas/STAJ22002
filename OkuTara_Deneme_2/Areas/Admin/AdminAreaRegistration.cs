using System.Web.Mvc;

namespace OkuTara_Deneme_2.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //AdminHome
            //Admin Index sayfası için özel route
            context.MapRoute(
                name: "Admin_dashboard",
                url: "admin-anasayfa",
                defaults: new { controller = "AdminHome", action = "Index" }
            );

            //AdminHome Privacy sayfası için özel route
            context.MapRoute(
                name: "AdminPrivacy",
                url: "admin-gizlilik",
                defaults: new { controller = "AdminHome", action = "Privacy" }
            );

            //AdminHome TermsAndConditions sayfası için özel route
            context.MapRoute(
                name: "AdminTermsAndConditions",
                url: "admin-kullanim-kosullari",
                defaults: new { controller = "AdminHome", action = "TermsAndConditions" }
            );

            

            //AdminProfile
            //Admin Profile sayfası için özel route
            context.MapRoute(
                name: "AdminProfile",
                url: "admin-profil",
                defaults: new { controller = "AdminProfile", action = "Index" }
            );

            //AdminGeneralSettings
            //Admin GeneralSettings sayfası için özel route
            context.MapRoute(
                name: "AdminGeneralSettings",
                url: "admin-genel-ayarlar",
                defaults: new { controller = "AdminGeneralSettings", action = "Index" }
            );

            //AdminGeneralSettings GeneralSettingsUpdate sayfası için özel route
            context.MapRoute(
                name: "AdminGeneralSettingsUpdate",
                url: "admin-genel-ayarlar-guncelle/{id}",
                defaults: new { controller = "AdminGeneralSettings", action = "Edit", id = UrlParameter.Optional }
            );

            //AdminGeneralSettings Create sayfası için özel route
            context.MapRoute(
                name: "AdminGeneralSettingsCreate",
                url: "admin-genel-ayarlar-ekle",
                defaults: new { controller = "AdminGeneralSettings", action = "Create" }
            );

            //AdminUser
            //Admin kullanıcı düzen sayfası için özel route
            context.MapRoute(
                name: "AdminUser",
                url: "admin-kullanici",
                defaults: new { controller = "AdminUser", action = "Index" }
            );

            //AdminUser Details sayfası için özel route
            context.MapRoute(
                name: "AdminUserDetail",
                url: "admin-kullanici-detay/{id}",
                defaults: new { controller = "AdminUser", action = "Detail", id = UrlParameter.Optional }
            );

            //AdminUser UserUpdate sayfası için özel route
            context.MapRoute(
                name: "AdminUserUpdate",
                url: "admin-kullanici-yetki-ekle/{id}",
                defaults: new { controller = "AdminUser", action = "UserRoleAdd", id = UrlParameter.Optional }
            );

            //AdminMessage
            //Mesajlar sayfası için özel route
            context.MapRoute(
                name: "AdminMessage",
                url: "admin-mesajlar",
                defaults: new { controller = "AdminMessage", action = "Index" }
            );

            //Admin Message sayfası için özel route
            context.MapRoute(
                name: "AdminMessageDetail",
                url: "admin-mesajlar-detay/{id}",
                defaults: new { controller = "AdminMessage", action = "ContactDetail", id = UrlParameter.Optional }
            );

            //AdminRole
            //Admin Role sayfası için özel route
            context.MapRoute(
                name: "AdminRole",
                url: "admin-rol",
                defaults: new { controller = "AdminRole", action = "Index" }
            );

            //AdminRole RoleAdd sayfası için özel route
            context.MapRoute(
                name: "AdminRoleAdd",
                url: "admin-rol-ekle",
                defaults: new { controller = "AdminRole", action = "RoleAdd" }
            );

            //AdminRole RoleDetails sayfası için özel route
            context.MapRoute(
                name: "AdminRoleDetails",
                url: "admin-rol-detay/{id}",
                defaults: new { controller = "AdminRole", action = "RoleDetails", id = UrlParameter.Optional }
            );

            //AdminRole RoleRemove linki için özel route
            context.MapRoute(
                name: "AdminRoleRemove",
                url: "admin-rol-sil/{id}",
                defaults: new { controller = "AdminRole", action = "RoleRemove", id = UrlParameter.Optional }
            );

            //Statistic sayfası için özel route
            context.MapRoute(
                name: "AdminStatistic",
                url: "istatistik",
                defaults: new { controller = "Statistic", action = "Index" }
            );

            //AdminPages
            //Admin Pages sayfası için özel route
            context.MapRoute(
                name: "AdminPages",
                url: "admin-sayfalar",
                defaults: new { controller = "AdminPages", action = "Index" }
            );

            //Admin Sayfa İçerikleri sayfası için özel route
            context.MapRoute(
                name: "AdminPageContent",
                url: "admin-sayfa-icerikleri",
                defaults: new { controller = "AdminPages", action = "HomePageContent"}
            );

            //Admin PageDetails sayfası için özel route
            context.MapRoute(
                name: "AdminPageDetails",
                url: "admin-sayfa-detay/{id}",
                defaults: new { controller = "AdminPages", action = "PageDetails", id = UrlParameter.Optional }
            );

            //Admin About sayfası için özel route
            context.MapRoute(
                name: "AdminAbout",
                url: "admin-hakkimizda",
                defaults: new { controller = "AdminAbout", action = "Index" }
            );

            //Admin Slider sayfası için özel route
            context.MapRoute(
                name: "AdminHomeSliderPhoto",
                url: "admin-slider",
                defaults: new { controller = "AdminHomeSliderPhoto", action = "Index" }
            );

            //Admin Slider AddPhoto sayfası için özel route
            context.MapRoute(
                name: "AdminHomeSliderPhotoAdd",
                url: "admin-slider-ekle",
                defaults: new { controller = "AdminHomeSliderPhoto", action = "AddPhoto" }
            );

            //Admin LogOut sayfası için özel route
            context.MapRoute(
                name: "AdminLogOut",
                url: "admin-cikis",
                defaults: new { controller = "AdminSession", action = "AdminLogOut" }
            );

            context.MapRoute(
                name: "Admin_default",
                url: "admin/{controller}/{action}/{id}",
                defaults: new { controller = "AdminSession", action = "AdminLogin", id = UrlParameter.Optional }
            );
        }
    }
}