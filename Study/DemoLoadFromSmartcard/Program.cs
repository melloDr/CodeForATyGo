using System;
using System.Diagnostics;
using Aspose.Words;
using Aspose.Words.DigitalSignatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoLoadFromSmartcard
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use a FileFormatInfo instance to verify that a document is not digitally signed.
            /*FileFormatInfo info = FileFormatUtil.DetectFileFormat("E:/Document.docx");

            Assert.AreEqual(".docx", FileFormatUtil.LoadFormatToExtension(info.LoadFormat));
            Assert.IsFalse(info.HasDigitalSignature);

            // Sign the document.
            CertificateHolder certificateHolder = CertificateHolder.Create("E:/morzal.pfx", "aw", null);
            DigitalSignatureUtil.Sign("E:/Document.docx", "E:/File.DetectDigitalSignatures.docx",
            certificateHolder, new SignOptions() { SignTime = DateTime.Now });

            // Use a new FileFormatInfo instance to confirm that it is signed.
            info = FileFormatUtil.DetectFileFormat("E:/File.DetectDigitalSignatures.docx");
            Assert.IsTrue(info.HasDigitalSignature);

            // The signatures can then be accessed like this.
            Assert.AreEqual(1, DigitalSignatureUtil.LoadSignatures("E:/File.DetectDigitalSignatures.docx").Count);*/









            // This example requires the Chilkat API to have been previously unlocked.
            // See Global Unlock Sample for sample code.

            Chilkat.Cert cert = new Chilkat.Cert();

            // To load the certificate specified by its hexidecimal serial number, pass the string "serial=<hexSerialNumber>".  For example:
            bool success = cert.LoadFromSmartcard("serial=4A1E6ADCF59DB1EFBAAE438D2C52664E40D16A87");
            if (success == false)
            {
                Debug.WriteLine(cert.LastErrorText);
                Debug.WriteLine("Certificate not loaded.");
                return;
            }

            Debug.WriteLine("Found: " + cert.SubjectDN + " serial=" + cert.SerialNumber);
            Console.WriteLine("Found: " + cert.SubjectDN + " serial=" + cert.SerialNumber);

            // Here's another example.
            // Note: serial numbers can be of different lengths.  The length of the serial number depends on the certificate.
            Chilkat.Cert cert2 = new Chilkat.Cert();
            success = cert2.LoadFromSmartcard("serial=66BE58138D761E92BC594A722932657BE26D421F");
            if (success == false)
            {
                Debug.WriteLine(cert2.LastErrorText);
                Debug.WriteLine("Certificate not loaded.");
                return;
            }

            Debug.WriteLine("Found: " + cert2.SubjectDN + " serial=" + cert2.SerialNumber);
        }
    }
}

