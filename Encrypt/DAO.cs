using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Encrypt
{
    class EncryptClass
    {
        private string Encrypt(string plainText, string Password, byte[] IV)
        {
            byte[] Key = Encoding.UTF8.GetBytes(Password);

            // Create a new AesManaged.    
            AesManaged aes = new AesManaged();
            aes.Key = Key;
            aes.IV = IV;

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fs = File.Open(@"C:\Users\Admin\Desktop\doc.txt", FileMode.Open);
            byte[] b = new byte[fs.Length];
            fs.Read(b, 0, b.Length);
            string result = System.Text.Encoding.UTF8.GetString(b);

            byte[] InputBytes = Encoding.UTF8.GetBytes(plainText);
            cryptoStream.Write(b, 0, b.Length);
            cryptoStream.FlushFinalBlock();

            byte[] Encrypted = memoryStream.ToArray();
            // Return encrypted data    
            return Convert.ToBase64String(Encrypted);
        }
    }
}
