using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GrandRepairAuto.Helpers
{
    public static class AvatarHelper
    {
        private const string GravatarTemplate = "https://www.gravatar.com/avatar/{0}?d=retro&s={1}";

        public static string AvatarUrlForEmail(this IHtmlHelper _, string email, int size = 80)
        {
            using var md5 = MD5.Create();
            byte[] emailBytes = Encoding.UTF8.GetBytes(email.Trim().ToLower());
            byte[] emailMd5Bytes = md5.ComputeHash(emailBytes);

            string emailMd5 = string.Concat(emailMd5Bytes.Select(b => b.ToString("x2")));

            return string.Format(GravatarTemplate, emailMd5, size);
        }
    }
}
