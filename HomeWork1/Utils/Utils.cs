using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HomeWork1.Utils
{
    public class CryptographyUtils
    {
        public static String SHA256Cryp(String str)
        {
            SHA256 sha256 = new SHA256CryptoServiceProvider();//建立一個SHA256
            byte[] source = Encoding.Default.GetBytes(str);//將字串轉為Byte[]
            byte[] crypto = sha256.ComputeHash(source);//進行SHA256加密
            return Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
        }

        /// <summary>
        /// object properties copy
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="toObject"></param>
        public static void CloneObject(object fromObj, object toObject)
        {
            Type f = fromObj.GetType();
            PropertyInfo[] fPros = f.GetProperties();

            Type t = toObject.GetType();
            PropertyInfo[] tPros = t.GetProperties();

            foreach (PropertyInfo tp in tPros)
            {
                foreach (PropertyInfo fp in fPros)
                {
                    if ("EntityKey" != tp.Name) //這是因為要防止Entity特殊屬性的複製
                    {
                        if (tp.CanWrite && tp.Name == fp.Name)
                        {
                            tp.SetValue(toObject, fp.GetValue(fromObj, null), null);
                            break;
                        }
                    }
                }
            }
        }
    }
}
