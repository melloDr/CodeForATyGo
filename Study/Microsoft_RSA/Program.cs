using System;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft_RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Create a UnicodeEncoder to convert between byte array and string.
                UnicodeEncoding ByteConverter = new UnicodeEncoding();

                //Create byte arrays to hold original, encrypted, and decrypted data.
                byte[] dataToEncrypt = ByteConverter.GetBytes("Hà gánh team còng lưng");
                byte[] encryptedData;
                byte[] decryptedData;

                //Create a new instance of RSACryptoServiceProvider to generate
                //public and private key data.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Pass the data to ENCRYPT, the public key information 
                    //(using RSACryptoServiceProvider.ExportParameters(false),
                    //and a boolean flag specifying no OAEP padding.
                    encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false); //Cái này e debug thì nó có 128 byte trong này
                    Console.WriteLine("EncryptedData: {0}", ByteConverter.GetString(encryptedData));

                    //Pass the data to DECRYPT, the private key information 
                    //(using RSACryptoServiceProvider.ExportParameters(true),
                    //and a boolean flag specifying no OAEP padding.
                    decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);//nó bị ở đây nè

                    //Display the decrypted plaintext to the console. 
                    Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));
                }
            }
            catch (ArgumentNullException)
            {
                //Catch this exception in case the encryption did
                //not succeed.
                Console.WriteLine("Encryption failed.");
            }
        }

        public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import the RSA Key information. This only needs
                    //toinclude the public key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Encrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                    byte[] GetPublicKey = RSA.ExportRSAPublicKey();
                    byte[] GetPrivateKey = RSA.ExportRSAPrivateKey();

                    //Code Mello Add
                    UnicodeEncoding ByteConverter = new UnicodeEncoding();
                    Console.WriteLine("Public Key: ", ByteConverter.GetString(encryptedData));
                    Console.WriteLine("Private Key: ", ByteConverter.GetString(encryptedData));
                }
                return encryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //Import the RSA Key information. This needs
                    //to include the private key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }
        }
    }
}
