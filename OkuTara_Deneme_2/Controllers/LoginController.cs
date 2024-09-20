using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using OkuTara_Deneme_2.Models.Classes;
using QRCoder;
using YourProjectNamespace.Helpers;
using System.Data.Entity.Validation;
using System.Web;

namespace OkuTara_Deneme_2.Controllers
{
    public class LoginController : BaseController
    {
        Context c = new Context();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        

        [HttpPost]
        public ActionResult SignUp(User p)
        {
            if (ModelState.IsValid)
            {
                var existingUser = c.Users.FirstOrDefault(x => x.UserEmail == p.UserEmail);

                if (existingUser == null)
                {
                    string baseUrl = "https://localhost:44394/QRContent/ShowUser";

                    // Şifreyi şifrele
                    p.UserPassword = PasswordHelper.Encrypt(p.UserPassword);
                    c.Users.Add(p);
                    c.SaveChanges();
                    TempData["SignUpMessage"] = "Kayıt başarılı. Giriş Yapabilirsiniz.";

                    // Kullanıcının kaydedildiğini doğrulama
                    var savedUser = c.Users.FirstOrDefault(x => x.UserEmail == p.UserEmail);
                    if (savedUser == null)
                    {
                        TempData["SignUpMessage"] = "Kullanıcı kaydedilemedi.";
                        return View();
                    }

                    using (MemoryStream ms = new MemoryStream())
                    {
                        QRCodeGenerator kodUret = new QRCodeGenerator();

                        QRCodeGenerator.QRCode karekod = kodUret.CreateQrCode($"{baseUrl}/{savedUser.UserId}", QRCodeGenerator.ECCLevel.H);

                        using (Bitmap resim = karekod.GetGraphic(10))
                        {
                            resim.Save(ms, ImageFormat.Png);

                            string qrCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());

                            var qrCode = new QRCode
                            {
                                QRCodeData = qrCodeImage,
                                QRCodeDate = DateTime.Now,
                                UserId = p.UserId 
                            };

                            c.QRCodes.Add(qrCode);
                            c.SaveChanges();

                            
                        }
                    }

                    //Kullanıcı kaydolduğu anda QRContent içeriğini oluşturur.
                    var qrContent = new QRCodeContent
                    {
                        GeneralMessage = null,
                        InstagramUrl = null,
                        InstagramState = false,
                        FacebookUrl = null,
                        FacebookState = false,
                        XUrl = null,
                        XState = false,
                        WhatsappUrl = null,
                        WhatsappState = false,
                        UserId = p.UserId,
                        QRCodeId = c.QRCodes.FirstOrDefault(x => x.UserId == p.UserId).QRId
                    };

                    c.QRCodeContents.Add(qrContent);
                    c.SaveChanges();

                }
                else
                {
                    TempData["SignUpMessage"] = "Bu email zaten kullanılıyor. Farklı bir email deneyin.";
                }
            }

            //return RedirectToAction("UserLogin", "Login");
            return View();
        }

        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(User p)
        {
            var user = c.Users.FirstOrDefault(x => x.UserEmail == p.UserEmail);

            if (user != null && PasswordHelper.Verify(p.UserPassword, user.UserPassword))
            {
                FormsAuthentication.SetAuthCookie(user.UserEmail, false); // Kullanıcı bilgilerini cookie'ye atar.

                //FormsAuthentication.SetAuthCookie(user.UserName, false); // Kullanıcı bilgilerini cookie'ye atar.
                //FormsAuthentication.SetAuthCookie(user.UserId.ToString(), false); // Kullanıcı bilgilerini cookie'ye atar.
                Session["UserEmail"] = user.UserEmail.ToString(); // Session'da UserEmail bilgisini tutar.
                //Session["UserId"] = user.UserId; // UserId'yi oturuma kaydet
                //Session["Username"] = user.UserName + " " + user.UserSurname;
                return RedirectToAction("Index", "UserProfile");
            }
            else
            {
                TempData["LoginErrorMessage"] = "Email veya şifreniz hatalı. Lutfen tekrar deneyiniz.";
                return RedirectToAction("UserLogin", "Login");
            }
        }

        

        public ActionResult Logout()
        {
            Session["Username"] = null;

            FormsAuthentication.SignOut(); // Kullanıcı oturumunu sonlandır
            Session.Abandon(); // Tüm session bilgilerini temizle

            return RedirectToAction("Index", "HomeDefault"); // Login sayfasına yönlendir
        }
    }
}
