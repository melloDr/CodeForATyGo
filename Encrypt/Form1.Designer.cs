
namespace Encrypt
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Obsolete]
        private void InitializeComponent()
        {
            this.btExit = new System.Windows.Forms.Button();
            this.btEncrypt = new System.Windows.Forms.Button();
            this.btEncryptReceive = new System.Windows.Forms.Button();
            this.btEncryptChoose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEncryptReceive = new System.Windows.Forms.TextBox();
            this.tbEncryptChoose = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btDecrypt = new System.Windows.Forms.Button();
            this.btDecryptReceive = new System.Windows.Forms.Button();
            this.btDecryptChoose = new System.Windows.Forms.Button();
            this.tbDecryptReceive = new System.Windows.Forms.TextBox();
            this.tbDecryptChoose = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btCompare = new System.Windows.Forms.Button();
            this.btDecryptFile = new System.Windows.Forms.Button();
            this.btEncryptFile = new System.Windows.Forms.Button();
            this.tbDecryptFile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbEncryptFile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbInfor = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(465, 415);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 17;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btEncrypt
            // 
            this.btEncrypt.Location = new System.Drawing.Point(448, 38);
            this.btEncrypt.Name = "btEncrypt";
            this.btEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btEncrypt.TabIndex = 16;
            this.btEncrypt.Text = "Encrypt";
            this.btEncrypt.UseVisualStyleBackColor = true;
            this.btEncrypt.Click += new System.EventHandler(this.btEncrypt_Click);
            // 
            // btEncryptReceive
            // 
            this.btEncryptReceive.Location = new System.Drawing.Point(367, 59);
            this.btEncryptReceive.Name = "btEncryptReceive";
            this.btEncryptReceive.Size = new System.Drawing.Size(75, 23);
            this.btEncryptReceive.TabIndex = 15;
            this.btEncryptReceive.Text = "Browse";
            this.btEncryptReceive.UseVisualStyleBackColor = true;
            this.btEncryptReceive.Click += new System.EventHandler(this.btReceive_Click);
            // 
            // btEncryptChoose
            // 
            this.btEncryptChoose.Location = new System.Drawing.Point(367, 18);
            this.btEncryptChoose.Name = "btEncryptChoose";
            this.btEncryptChoose.Size = new System.Drawing.Size(75, 23);
            this.btEncryptChoose.TabIndex = 14;
            this.btEncryptChoose.Text = "Browse";
            this.btEncryptChoose.UseVisualStyleBackColor = true;
            this.btEncryptChoose.Click += new System.EventHandler(this.btChoose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Choose location to receive file";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Choose file to encrypt";
            // 
            // tbEncryptReceive
            // 
            this.tbEncryptReceive.Location = new System.Drawing.Point(8, 59);
            this.tbEncryptReceive.Name = "tbEncryptReceive";
            this.tbEncryptReceive.Size = new System.Drawing.Size(353, 20);
            this.tbEncryptReceive.TabIndex = 11;
            // 
            // tbEncryptChoose
            // 
            this.tbEncryptChoose.Location = new System.Drawing.Point(8, 20);
            this.tbEncryptChoose.Name = "tbEncryptChoose";
            this.tbEncryptChoose.Size = new System.Drawing.Size(353, 20);
            this.tbEncryptChoose.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btEncrypt);
            this.panel1.Controls.Add(this.btEncryptReceive);
            this.panel1.Controls.Add(this.btEncryptChoose);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbEncryptReceive);
            this.panel1.Controls.Add(this.tbEncryptChoose);
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 116);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btDecrypt);
            this.panel2.Controls.Add(this.btDecryptReceive);
            this.panel2.Controls.Add(this.btDecryptChoose);
            this.panel2.Controls.Add(this.tbDecryptReceive);
            this.panel2.Controls.Add(this.tbDecryptChoose);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(4, 127);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 126);
            this.panel2.TabIndex = 19;
            // 
            // btDecrypt
            // 
            this.btDecrypt.Location = new System.Drawing.Point(448, 43);
            this.btDecrypt.Name = "btDecrypt";
            this.btDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btDecrypt.TabIndex = 17;
            this.btDecrypt.Text = "Decrypt";
            this.btDecrypt.UseVisualStyleBackColor = true;
            this.btDecrypt.Click += new System.EventHandler(this.btDecrypt_Click);
            // 
            // btDecryptReceive
            // 
            this.btDecryptReceive.Location = new System.Drawing.Point(367, 62);
            this.btDecryptReceive.Name = "btDecryptReceive";
            this.btDecryptReceive.Size = new System.Drawing.Size(75, 23);
            this.btDecryptReceive.TabIndex = 18;
            this.btDecryptReceive.Text = "Browse";
            this.btDecryptReceive.UseVisualStyleBackColor = true;
            this.btDecryptReceive.Click += new System.EventHandler(this.btDecryptReceive_Click);
            // 
            // btDecryptChoose
            // 
            this.btDecryptChoose.Location = new System.Drawing.Point(367, 23);
            this.btDecryptChoose.Name = "btDecryptChoose";
            this.btDecryptChoose.Size = new System.Drawing.Size(75, 23);
            this.btDecryptChoose.TabIndex = 17;
            this.btDecryptChoose.Text = "Browse";
            this.btDecryptChoose.UseVisualStyleBackColor = true;
            this.btDecryptChoose.Click += new System.EventHandler(this.btDecryptChoose_Click);
            // 
            // tbDecryptReceive
            // 
            this.tbDecryptReceive.Location = new System.Drawing.Point(8, 64);
            this.tbDecryptReceive.Name = "tbDecryptReceive";
            this.tbDecryptReceive.Size = new System.Drawing.Size(353, 20);
            this.tbDecryptReceive.TabIndex = 17;
            // 
            // tbDecryptChoose
            // 
            this.tbDecryptChoose.Location = new System.Drawing.Point(8, 25);
            this.tbDecryptChoose.Name = "tbDecryptChoose";
            this.tbDecryptChoose.Size = new System.Drawing.Size(353, 20);
            this.tbDecryptChoose.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Choose location to receive file";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Choose file to Decrypt";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btCompare);
            this.panel3.Controls.Add(this.btDecryptFile);
            this.panel3.Controls.Add(this.btEncryptFile);
            this.panel3.Controls.Add(this.tbDecryptFile);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.tbEncryptFile);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(4, 259);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(536, 130);
            this.panel3.TabIndex = 20;
            // 
            // btCompare
            // 
            this.btCompare.Location = new System.Drawing.Point(448, 44);
            this.btCompare.Name = "btCompare";
            this.btCompare.Size = new System.Drawing.Size(75, 23);
            this.btCompare.TabIndex = 20;
            this.btCompare.Text = "Compare";
            this.btCompare.UseVisualStyleBackColor = true;
            // 
            // btDecryptFile
            // 
            this.btDecryptFile.Location = new System.Drawing.Point(370, 63);
            this.btDecryptFile.Name = "btDecryptFile";
            this.btDecryptFile.Size = new System.Drawing.Size(75, 23);
            this.btDecryptFile.TabIndex = 20;
            this.btDecryptFile.Text = "Browse";
            this.btDecryptFile.UseVisualStyleBackColor = true;
            this.btDecryptFile.Click += new System.EventHandler(this.btDecryptFile_Click);
            // 
            // btEncryptFile
            // 
            this.btEncryptFile.Location = new System.Drawing.Point(370, 24);
            this.btEncryptFile.Name = "btEncryptFile";
            this.btEncryptFile.Size = new System.Drawing.Size(75, 23);
            this.btEncryptFile.TabIndex = 21;
            this.btEncryptFile.Text = "Browse";
            this.btEncryptFile.UseVisualStyleBackColor = true;
            this.btEncryptFile.Click += new System.EventHandler(this.btEncryptFile_Click);
            // 
            // tbDecryptFile
            // 
            this.tbDecryptFile.Location = new System.Drawing.Point(11, 65);
            this.tbDecryptFile.Name = "tbDecryptFile";
            this.tbDecryptFile.Size = new System.Drawing.Size(353, 20);
            this.tbDecryptFile.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Choose decrypt file ";
            // 
            // tbEncryptFile
            // 
            this.tbEncryptFile.Location = new System.Drawing.Point(11, 26);
            this.tbEncryptFile.Name = "tbEncryptFile";
            this.tbEncryptFile.Size = new System.Drawing.Size(353, 20);
            this.tbEncryptFile.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Choose encrypt file ";
            // 
            // lbInfor
            // 
            this.lbInfor.AutoSize = true;
            this.lbInfor.Location = new System.Drawing.Point(9, 428);
            this.lbInfor.Name = "lbInfor";
            this.lbInfor.Size = new System.Drawing.Size(65, 13);
            this.lbInfor.TabIndex = 21;
            this.lbInfor.Text = "Information: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 450);
            this.Controls.Add(this.lbInfor);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btExit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btEncrypt;
        private System.Windows.Forms.Button btEncryptReceive;
        private System.Windows.Forms.Button btEncryptChoose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEncryptReceive;
        private System.Windows.Forms.TextBox tbEncryptChoose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btDecrypt;
        private System.Windows.Forms.Button btDecryptReceive;
        private System.Windows.Forms.Button btDecryptChoose;
        private System.Windows.Forms.TextBox tbDecryptReceive;
        private System.Windows.Forms.TextBox tbDecryptChoose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btCompare;
        private System.Windows.Forms.Button btDecryptFile;
        private System.Windows.Forms.Button btEncryptFile;
        private System.Windows.Forms.TextBox tbDecryptFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbEncryptFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbInfor;
    }
}

