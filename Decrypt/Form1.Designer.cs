
namespace Decrypt
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
            this.components = new System.ComponentModel.Container();
            this.tbChoose = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbReceive = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btChoose = new System.Windows.Forms.Button();
            this.btReceive = new System.Windows.Forms.Button();
            this.btDecrypt = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbChoose
            // 
            this.tbChoose.Location = new System.Drawing.Point(92, 88);
            this.tbChoose.Name = "tbChoose";
            this.tbChoose.Size = new System.Drawing.Size(353, 20);
            this.tbChoose.TabIndex = 0;
            this.tbChoose.TextChanged += new System.EventHandler(this.tbChoose_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tbReceive
            // 
            this.tbReceive.Location = new System.Drawing.Point(92, 206);
            this.tbReceive.Name = "tbReceive";
            this.tbReceive.Size = new System.Drawing.Size(353, 20);
            this.tbReceive.TabIndex = 2;
            this.tbReceive.TextChanged += new System.EventHandler(this.tbReceive_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose file to decrypt";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Choose location to receive file";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btChoose
            // 
            this.btChoose.Location = new System.Drawing.Point(509, 88);
            this.btChoose.Name = "btChoose";
            this.btChoose.Size = new System.Drawing.Size(75, 23);
            this.btChoose.TabIndex = 6;
            this.btChoose.Text = "Browse";
            this.btChoose.UseVisualStyleBackColor = true;
            this.btChoose.Click += new System.EventHandler(this.btChoose_Click);
            // 
            // btReceive
            // 
            this.btReceive.Location = new System.Drawing.Point(509, 204);
            this.btReceive.Name = "btReceive";
            this.btReceive.Size = new System.Drawing.Size(75, 23);
            this.btReceive.TabIndex = 7;
            this.btReceive.Text = "Browse";
            this.btReceive.UseVisualStyleBackColor = true;
            this.btReceive.Click += new System.EventHandler(this.btReceive_Click);
            // 
            // btDecrypt
            // 
            this.btDecrypt.Location = new System.Drawing.Point(348, 302);
            this.btDecrypt.Name = "btDecrypt";
            this.btDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btDecrypt.TabIndex = 8;
            this.btDecrypt.Text = "Decrypt";
            this.btDecrypt.UseVisualStyleBackColor = true;
            this.btDecrypt.Click += new System.EventHandler(this.btDecrypt_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(713, 415);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 9;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btDecrypt);
            this.Controls.Add(this.btReceive);
            this.Controls.Add(this.btChoose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbReceive);
            this.Controls.Add(this.tbChoose);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbChoose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tbReceive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btChoose;
        private System.Windows.Forms.Button btReceive;
        private System.Windows.Forms.Button btDecrypt;
        private System.Windows.Forms.Button btExit;
    }
}

