using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Utils
{
    public static class Crypto
    {

        public static string Encrypt(string ClearData, string EncryptionKey)
        {
            try
            {
                byte[] clearBytes = Encoding.Unicode.GetBytes(ClearData);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        ClearData = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return ClearData;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                return ClearData;
                //throw;
            }
        }

        public static string Decrypt(string CipherData, string EncryptionKey)
        {
            try
            {
                CipherData = CipherData.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(CipherData);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        CipherData = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return CipherData;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                return CipherData;
                //throw;
            }
        }
    }
}
