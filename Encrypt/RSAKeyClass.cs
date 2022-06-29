using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Org.BouncyCastle.Crypto;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Generators;
using System.IO;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Digests;

namespace Encrypt
{
    class RSAKeyClass
    {
        [Obsolete]
        public static void Create2Keys()
        {
            AsymmetricCipherKeyPair CertificateKey;

            //let us first generate the root certificate
            X509Certificate2 X509RootCert = CreateCertificate("C=GB, ST=Berkshire, L=Reading, O=MY COMPANY", "CN =MYCOMPANY ROOT CA", (int)2, out CertificateKey);
            //now let us write the certificates files to the folder 
            File.WriteAllBytes("E:\\Crypt\\RSA_Key" + "\\" + "X509Cert.der", X509RootCert.RawData);
            // E:\\worldFileExample -- E:\\Crypt\\RSA_Key

            string PublicPEMFile = "E:\\Crypt\\RSA_Key" + "\\" + "X509Cert-public.pem";
            string PrivatePEMFile = "E:\\Crypt\\RSA_Key" + "\\" + "X509Cert-private.pem";
            //now let us also create the PEM file as well in case we need it
            using (TextWriter textWriter = new StreamWriter(PublicPEMFile, false))
            {
                PemWriter pemWriter = new PemWriter(textWriter);
                pemWriter.WriteObject(CertificateKey.Public);
                pemWriter.Writer.Flush();
            }
            //now let us also create the PEM file as well in case we need it
            using (TextWriter textWriter = new StreamWriter(PrivatePEMFile, false))
            {
                PemWriter pemWriter = new PemWriter(textWriter);
                pemWriter.WriteObject(CertificateKey.Private);
                pemWriter.Writer.Flush();
            }

        }

        [Obsolete]
        public static X509Certificate2 CreateCertificate(string subjectName, string issuer, int ValidMonths, out AsymmetricCipherKeyPair KeyPair, int keyStrength = 2048)
        {
            ValidMonths = (int)2;
            subjectName = "C=GB, ST=Berkshire, L=Reading, O=MY COMPANY";
            issuer = "CN=MYCOMPANY ROOT CA";
            // Generating Random Numbers
            CryptoApiRandomGenerator randomGenerator = new CryptoApiRandomGenerator();
            var random = new SecureRandom(randomGenerator);

            // The Certificate Generator
            X509V3CertificateGenerator certificateGenerator = new X509V3CertificateGenerator();

            // Serial Number
            var serialNumber = BigIntegers.CreateRandomInRange(Org.BouncyCastle.Math.BigInteger.One, Org.BouncyCastle.Math.BigInteger.ValueOf(Int64.MaxValue), random);
            certificateGenerator.SetSerialNumber(serialNumber);

            // Issuer and Subject Name
            var subjectDN = new X509Name(subjectName);
            var issuerDN = new X509Name(issuer);
            certificateGenerator.SetIssuerDN(issuerDN);
            certificateGenerator.SetSubjectDN(subjectDN);

            // Valid For
            var notBefore = DateTime.UtcNow.Date;
            var notAfter = notBefore.AddMonths(ValidMonths);

            certificateGenerator.SetNotBefore(notBefore);
            certificateGenerator.SetNotAfter(notAfter);

            certificateGenerator.AddExtension(X509Extensions.KeyUsage.Id, true, new KeyUsage(KeyUsage.KeyEncipherment));

            // Subject Public Key
            AsymmetricCipherKeyPair subjectKeyPair;
            var keyGenerationParameters = new KeyGenerationParameters(random, keyStrength);
            var keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(keyGenerationParameters);
            subjectKeyPair = keyPairGenerator.GenerateKeyPair();

            certificateGenerator.SetPublicKey(subjectKeyPair.Public);

            // Generating the Certificate
            var issuerKeyPair = subjectKeyPair;
            KeyPair = subjectKeyPair;

            // Selfsign certificate
            certificateGenerator.SetSignatureAlgorithm("SHA256WithRSA");
            var certificate = certificateGenerator.Generate(issuerKeyPair.Private, random);
            certificate.CheckValidity();
            var x509 = new System.Security.Cryptography.X509Certificates.X509Certificate2(certificate.GetEncoded());

            return x509;
        }

        [Obsolete]
        public static string EncryptWithPublicKey(string PEMFileName, string Text)
        {
            Create2Keys();

            byte[] BytesToOperateOn = Encoding.UTF8.GetBytes(Text);
            TextReader reader = File.OpenText(PEMFileName);
            AsymmetricKeyParameter KeyPair = (AsymmetricKeyParameter)new PemReader(reader).ReadObject();

            OaepEncoding Engine = new OaepEncoding(new RsaEngine(), new Sha256Digest(), new Sha256Digest(), null);
            Engine.Init(true, KeyPair);  //if encryption is true use public key else use private
            byte[] Output = Engine.ProcessBlock(BytesToOperateOn, 0, BytesToOperateOn.Length);
            string Result = Convert.ToBase64String(Output);
            return Result;
        }

    }
}
