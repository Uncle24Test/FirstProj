using System.Security.Cryptography;
using System.Text;

namespace TaShu.CourseManagement.Common
{
    public class MD5Provider
    {
        public static string GetMD5(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] b = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            string pwd = string.Empty;
            foreach (var item in b)
            {
                pwd += item.ToString();
            }
            return pwd;
        }
    }
}
