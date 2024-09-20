//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace OkuTara_Deneme_2.Helpers
//{
//    public class PasswordHelper
//    {
//    }
//}

using System;
using System.Security.Cryptography;
using System.Text;

namespace YourProjectNamespace.Helpers
{
    public static class PasswordHelper
    {
        // Şifreleme fonksiyonu
        public static string Encrypt(string plainText)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(plainText);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Şifreyi karşılaştırma fonksiyonu
        public static bool Verify(string plainText, string hash)
        {
            var hashOfInput = Encrypt(plainText);
            return StringComparer.OrdinalIgnoreCase.Compare(hashOfInput, hash) == 0;
        }
    }
}