using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Common.Helper
{
    public static class Md5Cryptograf
    {
        public static string md5sifreleme(this string metin)
        {

            metin += "!!YesilEv!!!Eren*Ferid";
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(metin));
            byte[] sonuc = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < sonuc.Length; i++)
            {
                strBuilder.Append(sonuc[i].ToString("x4"));
            }
            return strBuilder.ToString();

        }
    }
}
