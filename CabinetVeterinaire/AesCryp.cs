using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CabinetVeterinaire
{
    class AesCryp
    {
        // Key and IV must be at least 32 bytes
        public byte[] key = Encoding.UTF8.GetBytes("kdjfzel5zkd6eonf");
        public byte[] iv = Encoding.UTF8.GetBytes("ptrg9rej3ef5rjg6");
        public static string Encrypt(string plainText, byte[] key, byte[] iv)
        {
            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                rijndael.Key = key;
                rijndael.IV = iv;
                rijndael.Mode = CipherMode.CBC;
                rijndael.Padding = PaddingMode.PKCS7;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, rijndael.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                        
                        cs.Write(plainBytes, 0, plainBytes.Length);
                        cs.FlushFinalBlock();
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, byte[] key, byte[] iv)
        {
            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                rijndael.Key = key;
                rijndael.IV = iv;
                rijndael.Mode = CipherMode.CBC;
                rijndael.Padding = PaddingMode.PKCS7;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, rijndael.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipherText);
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.FlushFinalBlock();
                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
        }
    }






    /* public static string IV = "zkncjk43jn7ff87kdjn";
     public static string Key = "djkcn5jdkn6jkhn7dcelrf21idhf";

     public static string Encrypt(string decrypted)
     {
         byte[] textbytes = ASCIIEncoding.ASCII.GetBytes(decrypted);
         AesCryptoServiceProvider encdec = new AesCryptoServiceProvider();
         encdec.BlockSize = 128;
         encdec.KeySize = 256;
         encdec.Key = ASCIIEncoding.ASCII.GetBytes(Key);
         encdec.IV = ASCIIEncoding.ASCII.GetBytes(IV);
         encdec.Padding = PaddingMode.PKCS7;
         encdec.Mode = CipherMode.CBC;

         ICryptoTransform icrypt = encdec.CreateEncryptor(encdec.Key, encdec.IV);
         byte[] enc = icrypt.TransformFinalBlock(textbytes,0,textbytes.Length);
         icrypt.Dispose();
         return Convert.ToBase64String(enc);
     }


     public static string Decrypt(string encrypted)
     {
         byte[] encbytes =  Convert.FromBase64String(encrypted);
         AesCryptoServiceProvider encdec = new AesCryptoServiceProvider();
         encdec.BlockSize = 128;
         encdec.KeySize = 256;
         encdec.Key = ASCIIEncoding.ASCII.GetBytes(Key);
         encdec.IV = ASCIIEncoding.ASCII.GetBytes(IV);
         encdec.Padding = PaddingMode.PKCS7;
         encdec.Mode = CipherMode.CBC;

         ICryptoTransform icrypt = encdec.CreateEncryptor(encdec.Key, encdec.IV);
         byte[] dec = icrypt.TransformFinalBlock(encbytes, 0, encbytes.Length);
         icrypt.Dispose();
         return ASCIIEncoding.ASCII.GetString(dec);
     }
    */

}
