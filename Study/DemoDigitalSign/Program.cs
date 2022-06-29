using System;
using System.Diagnostics;

namespace DemoDigitalSign
{
    class Program
    {
        static void Main(string[] args)
        {// This example requires the Chilkat API to have been previously unlocked.
         // See Global Unlock Sample for sample code.

            Chilkat.Pdf pdf = new Chilkat.Pdf();

            // Load a PDF to be signed.
            // The "hello.pdf" is available at https://chilkatsoft.com/hello.pdf
            bool success = pdf.LoadFile("E:/hello.pdf");
            if (success == false)
            {
                Debug.WriteLine(pdf.LastErrorText);
                return;
            }

            // Options for signing are specified in JSON.
            Chilkat.JsonObject json = new Chilkat.JsonObject();

            // In most cases, the signingCertificateV2 and signingTime attributes are required.
            json.UpdateInt("signingCertificateV2", 1);
            json.UpdateInt("signingTime", 1);

            // Put the signature on page 1, top left
            json.UpdateInt("page", 1);
            json.UpdateString("appearance.y", "top");
            json.UpdateString("appearance.x", "left");

            // Use a font scale of 10.0
            json.UpdateString("appearance.fontScale", "10.0");

            // In this example, the appearance of the digital signature will contain three lines:
            // 1) The signing certificate's common name
            // 2) The current date/time
            // 3) Some arbitrary text.
            // The keyword "cert_cn" is replaced with the Certificate's Subject Common Name.
            // The keyword "current_dt" is replaced with the current date/time.
            // Any number of appearance text lines can be added.
            json.UpdateString("appearance.text[0]", "Digitally signed by: cert_cn");
            json.UpdateString("appearance.text[1]", "current_dt");
            json.UpdateString("appearance.text[2]", "The crazy brown fox jumps over the lazy dog.");

            // Use a certificate on a smartcard or USB token.
            Chilkat.Cert cert = new Chilkat.Cert();
            // Load the certificate on the smartcard currently in the reader (or on the USB token).
            // Pass an empty string to allow Chilkat to automatically choose the CSP (Cryptographi Service Provider).
            // See Load Certificate on Smartcard for information about explicitly selecting a particular CSP.
            success = cert.LoadFromSmartcard("");
            if (success == false)
            {
                Debug.WriteLine(cert.LastErrorText);
                return;
            }

            // Provide the smartcard PIN.
            // If the PIN is not explicitly provided here, the Windows OS should
            // display a dialog for the PIN.
            cert.SmartCardPin = "123456";

            // Tell the pdf object to use the certificate for signing.
            success = pdf.SetSigningCert(cert);
            /* if (success == false)
             {
                 Debug.WriteLine(pdf.LastErrorText);
                 return;
             }*/

            success = pdf.SignPdf(json, "E:/hello_signed_hsm.pdf");
            /*if (success == false)
            {
                Debug.WriteLine(pdf.LastErrorText);
                return;
            }
*/
            Debug.WriteLine("The PDF has been successfully cryptographically signed using an HSM.");

        }
    }
}
