using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Decrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                tbChoose.Text = openFileDialog.FileName;
            }
        }

        private void btDecrypt_Click(object sender, EventArgs e)
        {

        }

        private void btReceive_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                tbReceive.Text = openFileDialog.FileName;
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbReceive_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbChoose_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
