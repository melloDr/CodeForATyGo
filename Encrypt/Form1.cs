using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Encrypt
{
    public partial class Form1 : Form
    {
        [Obsolete]
        public Form1()
        {
            InitializeComponent();
        }

        private void btChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "doc files(*.doc) | *.doc";
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                tbEncryptChoose.Text = openFileDialog.FileName;
            }


            /*OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                tbEncryptChoose.Text = openFileDialog.FileName;
            }*/
        }

        private void btReceive_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog FolderBrowser = new FolderBrowserDialog();
            FolderBrowser.Description = "Select the folder to store the certificates";
            DialogResult result = FolderBrowser.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                tbEncryptReceive.Text = FolderBrowser.SelectedPath;
                //buttonGenerate.Enabled = textBoxFolderName.Text.Length > 0;
            }

            /* OpenFileDialog openFileDialog = new OpenFileDialog();
             DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
             if (result == DialogResult.OK) // Test result.
             {
                 tbEncryptReceive.Text = openFileDialog.FileName;
             }*/
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btDecryptChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                tbDecryptChoose.Text = openFileDialog.FileName;
            }
        }

        private void btDecryptReceive_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog FolderBrowser = new FolderBrowserDialog();
            FolderBrowser.Description = "Select the folder to store the certificates";
            DialogResult result = FolderBrowser.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                tbDecryptReceive.Text = FolderBrowser.SelectedPath;
            }

            /*OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                tbDecryptReceive.Text = openFileDialog.FileName;
            }*/
        }

        private void btEncryptFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                tbEncryptFile.Text = openFileDialog.FileName;
            }
        }

        private void btDecryptFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                tbDecryptFile.Text = openFileDialog.FileName;
            }
        }

        [Obsolete]
        private void btEncrypt_Click(object sender, EventArgs e)
        {
            string password = "ThePasswordToDecryptAndEncryptTheFile";
            string EncryptRSAForPassword = "";

            // For additional security Pin the password of your files
            GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);

            // Encrypt the file
            AESClass.FileEncrypt(@tbEncryptChoose.Text, password, @tbEncryptReceive.Text);
            //@"C:\Users\username\Desktop\wordFileExample.doc"

            // To increase the security of the encryption, delete the given password from the memory !
            AESClass.ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
            gch.Free();

            // You can verify it by displaying its value later on the console (the password won't appear)
            lbInfor.Text = "Information: The given password is surely nothing: " + password;

            try
            {
                EncryptRSAForPassword = RSAKeyClass.EncryptWithPublicKey("E:\\Crypt\\RSA_Key\\X509Cert-public.pem", password);
                File.WriteAllText("E:\\Crypt\\RSA_Key\\EncryptAESKey\\WriteLines.txt", EncryptRSAForPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Decryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            /*bool check = false;
            string fileName = tbEncryptChoose.Text;
            check = CSCrypto.EncryptFile(fileName);
            if (check == true)
            {
                lbInfor.Text = "Information: File was encrypted successfully!";

            }
            else
            {
                lbInfor.Text = "Information: File was encrypted fail!";
            }*/

        }

        private void btDecrypt_Click(object sender, EventArgs e)
        {
            string password = "ThePasswordToDecryptAndEncryptTheFile";

            // For additional security Pin the password of your files
            GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);

            // Decrypt the file
            AESClass.FileDecrypt(tbDecryptChoose.Text, @tbDecryptReceive.Text + "\\example_decrypted.doc", password);

            // To increase the security of the decryption, delete the used password from the memory !
            AESClass.ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
            gch.Free();

            // You can verify it by displaying its value later on the console (the password won't appear)
            lbInfor.Text = "The given password is surely nothing: " + password;
        }
    }
}
