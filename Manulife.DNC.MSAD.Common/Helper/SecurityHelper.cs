using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Manulife.DNC.MSAD.Common
{
    public class SecurityHelper
    {
        /// <summary>  
        /// DES加密算法  
        /// key为8位或16位  
        /// </summary>  
        /// <param name="strString">待加密的字符串</param>  
        /// <param name="key">密钥</param>  
        /// <returns></returns>  
        public string DesEncrypt(string strString, string key)
        {
            StringBuilder ret = new StringBuilder();

            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.Default.GetBytes(strString);
                des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(key);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                ret.ToString();
            }
            catch { }

            return ret.ToString();
        }


        /// <summary>  
        /// DES解密算法  
        /// key为8位或16位  
        /// </summary>  
        /// <param name="strString">需要解密的字符串</param>  
        /// <param name="key">密钥</param>  
        /// <returns></returns>  
        public string DesDecrypt(string strString, string key)
        {
            MemoryStream ms = new MemoryStream();

            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = new byte[strString.Length / 2];
                for (int x = 0; x < strString.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(strString.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }
                des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                des.IV = ASCIIEncoding.ASCII.GetBytes(key);

                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
            }
            catch{}

            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
    }
}
