using System;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "ThePasswordToDecryptAndEncryptTheFile";

            // For additional security Pin the password of your files
            GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);

            // Encrypt the file
            ClassSup.FileEncrypt(@"C:\Users\Admin\Desktop\wordFileExample.doc", password);

            // To increase the security of the encryption, delete the given password from the memory !
            ClassSup.ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
            gch.Free();

            // You can verify it by displaying its value later on the console (the password won't appear)
            Console.WriteLine("The given password is surely nothing: " + password);
        }
    }
}
