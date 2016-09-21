// jieai崔健

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Helper
{
    public class MyEncrypt
    {
        /// <summary>
        /// 加密字符串返回Bytes
        /// </summary>
        /// <param name="plainText">要加密的文字</param>
        /// <param name="Key">密匙</param>
        /// <param name="IV">初始向量</param>
        /// <returns></returns>
        private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key,
            byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Aes object

            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key
                    , aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt
                        , encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(
                            csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="password">密码，必须16位</param>
        /// <returns></returns>
        public static string TryEncryptStringToString_Aes(string plainText, string password, out bool isok)
        {
            string result = "";
            isok = true;
            try
            {
                byte[] keys = Encoding.UTF8.GetBytes(password);
                var result2 = EncryptStringToBytes_Aes(plainText, keys, keys);
                result = Convert.ToBase64String(result2);
            }
            catch (Exception)
            {
                isok = false;
            }

            return result;
        }

        public static string EncryptStringToString_Aes(string plainText, string password)
        {
            byte[] keys = Encoding.UTF8.GetBytes(password);
            var result2 = EncryptStringToBytes_Aes(plainText, keys, keys);
            var result = Convert.ToBase64String(result2);


            return result;
        }

        private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key
            , byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key
                    , aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt
                        , decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(
                            csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting 
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        public static string TryDecryptStringFromString_Aes(string cipherText, string password,
            out bool isok)
        {
            string result = "";
            try
            {
                isok = true;
                byte[] keys = Encoding.UTF8.GetBytes(password);
                result = DecryptStringFromBytes_Aes(Convert.FromBase64String(cipherText), keys, keys);
            }
            catch (Exception)
            {
                isok = false;
            }
            return result;
        }

        public static string DecryptStringFromString_Aes(string cipherText, string password
            )
        {
            byte[] keys = Encoding.UTF8.GetBytes(password);
            var result = DecryptStringFromBytes_Aes(Convert.FromBase64String(cipherText), keys, keys);


            return result;
        }

        public static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            using (TripleDESCryptoServiceProvider tdsAlg = new TripleDESCryptoServiceProvider())
            {
                tdsAlg.Key = Key;
                tdsAlg.IV = IV;
                var encryptor= tdsAlg.CreateEncryptor(tdsAlg.Key, tdsAlg.IV);
                using (MemoryStream moStreamencrypt=new MemoryStream())
                {
                    using (CryptoStream csencrypt=new CryptoStream(moStreamencrypt,encryptor,CryptoStreamMode.Write))
                    {
                        using (StreamWriter swencrypt=new StreamWriter(csencrypt))
                        {
                            swencrypt.Write(plainText);
                        }
                        encrypted = moStreamencrypt.ToArray();
                    }
                }


            }
            return encrypted;
            
            
           





            return null;
        }
     }
}