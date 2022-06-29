
namespace CompareFile
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
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDecryptFile = new System.Windows.Forms.TextBox();
            this.tbEncryptFile = new System.Windows.Forms.TextBox();
            this.btCompare = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.btEncrypt = new System.Windows.Forms.Button();
            this.btDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose decrypt file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choose encrypt file";
            // 
            // tbDecryptFile
            // 
            this.tbDecryptFile.Location = new System.Drawing.Point(77, 71);
            this.tbDecryptFile.Name = "tbDecryptFile";
            this.tbDecryptFile.Size = new System.Drawing.Size(298, 20);
            this.tbDecryptFile.TabIndex = 2;
            // 
            // tbEncryptFile
            // 
            this.tbEncryptFile.Location = new System.Drawing.Point(77, 214);
            this.tbEncryptFile.Name = "tbEncryptFile";
            this.tbEncryptFile.Size = new System.Drawing.Size(298, 20);
            this.tbEncryptFile.TabIndex = 3;
            // 
            // btCompare
            // 
            this.btCompare.Location = new System.Drawing.Point(330, 325);
            this.btCompare.Name = "btCompare";
            this.btCompare.Size = new System.Drawing.Size(75, 23);
            this.btCompare.TabIndex = 4;
            this.btCompare.Text = "Compare";
            this.btCompare.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(713, 415);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 5;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btEncrypt
            // 
            this.btEncrypt.Location = new System.Drawing.Point(434, 214);
            this.btEncrypt.Name = "btEncrypt";
            this.btEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btEncrypt.TabIndex = 6;
            this.btEncrypt.Text = "Browse";
            this.btEncrypt.UseVisualStyleBackColor = true;
            this.btEncrypt.Click += new System.EventHandler(this.btEncrypt_Click);
            // 
            // btDecrypt
            // 
            this.btDecrypt.Location = new System.Drawing.Point(434, 71);
            this.btDecrypt.Name = "btDecrypt";
            this.btDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btDecrypt.TabIndex = 7;
            this.btDecrypt.Text = "Browse";
            this.btDecrypt.UseVisualStyleBackColor = true;
            this.btDecrypt.Click += new System.EventHandler(this.btDecrypt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btDecrypt);
            this.Controls.Add(this.btEncrypt);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btCompare);
            this.Controls.Add(this.tbEncryptFile);
            this.Controls.Add(this.tbDecryptFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDecryptFile;
        private System.Windows.Forms.TextBox tbEncryptFile;
        private System.Windows.Forms.Button btCompare;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btEncrypt;
        private System.Windows.Forms.Button btDecrypt;
    }
}

