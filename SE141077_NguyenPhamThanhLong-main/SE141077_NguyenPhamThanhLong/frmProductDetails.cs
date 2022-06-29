using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlbumAssemblies;

namespace SE141077_NguyenPhamThanhLong
{
    public partial class frmProductDetails : Form
    {

        private bool addorEdit;
        public Album ProductAddOrEdit { get; set; }
        public frmProductDetails()
        {
            InitializeComponent();
        }

        public frmProductDetails(bool flag, Album p) : this()
        {
            addorEdit = flag;
            ProductAddOrEdit = p;
            InitData();
        }

        private void InitData()
        {
            txtId.Enabled = false;
            txtId.Text = ProductAddOrEdit.AlbumID.ToString();
            txtName.Text = ProductAddOrEdit.AlbumName;
            txtYear.Text = ProductAddOrEdit.ReleaseYear.ToString();
            txtQuantity.Text = ProductAddOrEdit.Quantity.ToString();
            txtStatus.Text = ProductAddOrEdit.Status.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (valid())
            {

                bool flag;
                ProductAddOrEdit.AlbumID = int.Parse(txtId.Text);
                ProductAddOrEdit.AlbumName = txtName.Text;
                ProductAddOrEdit.ReleaseYear = int.Parse(txtYear.Text);
                ProductAddOrEdit.Quantity = int.Parse(txtQuantity.Text);
                ProductAddOrEdit.Status = int.Parse(txtStatus.Text);
                AlbumDB proData = new AlbumDB();

                if (addorEdit == true)
                {
                    flag = proData.AddNewProduct(ProductAddOrEdit);
                }
                else
                {
                    txtId.Enabled = false;
                    flag = proData.UpdateProduct(ProductAddOrEdit);
                }
                if (flag == true)
                {
                    MessageBox.Show("Save Success!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Save Fail!");
                }
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

        private bool valid()
        {
            string name = txtName.Text;
            string year = txtYear.Text;
            string quantity = txtQuantity.Text;
            string status = txtStatus.Text;
            if (name == string.Empty || year == string.Empty ||
                quantity == string.Empty || status == string.Empty)
            {
                MessageBox.Show("Must not empty");
                return false;
            }
            else
            {
                try
                {
                    if (int.Parse(year) <= 0)
                    {
                        year = "sss";
                    }
                    int.Parse(year);

                    if (int.Parse(quantity) <= 0)
                    {
                        quantity = "sss";
                    }
                    int.Parse(quantity);
                    int.Parse(year);
                    int.Parse(status);
                }
                catch (Exception)
                {
                    MessageBox.Show("Must be number >=0");
                    return false;
                }
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
          
}
