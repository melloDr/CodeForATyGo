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
    public partial class frmMaintainProduct : Form
    {

        AlbumDB bm = new AlbumDB();
        DataTable dtProduct;

        public frmMaintainProduct()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmMaintainProduct_Load(object sender, EventArgs e)
        {
            getAllBooks();
        }
        private void getAllBooks()
        {
            dtProduct = ConvertToDataTable(bm.GetProductList());
            dtProduct.PrimaryKey = new DataColumn[] { dtProduct.Columns["AlbumID"] };
            //DataColumn subTotal= dtProduct.Columns.Add("SubTotal", typeof(double), "Quantity*UnitPrice");
            //subTotal.ReadOnly = false;
            //DataColumn column = dtProduct.Columns.Add("Total");
            //column.DataType = System.Type.GetType("System.Decimal");
            //column.ReadOnly = true;
            //column.Expression = "UnitPrice * Quantity";
            //column.Unique = false;

            txtId.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtYear.DataBindings.Clear();
            txtQuantity.DataBindings.Clear();
            txtStatus.DataBindings.Clear();

            txtId.DataBindings.Add("Text", dtProduct, "AlbumID");
            txtName.DataBindings.Add("Text", dtProduct, "AlbumName");
            txtYear.DataBindings.Add("Text", dtProduct, "ReleaseYear");
            txtQuantity.DataBindings.Add("Text", dtProduct, "Quantity");
            txtStatus.DataBindings.Add("Text", dtProduct, "Status");

            txtId.Enabled = false;
            txtName.Enabled = false;
            txtYear.Enabled = false;
            txtQuantity.Enabled = false;
            txtStatus.Enabled = false;
            dgvProductList.DataSource = dtProduct;
        }

        private DataTable ConvertToDataTable(List<Album> data)
        {
            DataTable table = new DataTable();

            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(Album));

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name,
                    Nullable.GetUnderlyingType(prop.PropertyType) ??
                    prop.PropertyType);
            }
            foreach (Album item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int AlbumID = 1;
            string AlbumName = string.Empty;
            int ReleaseYear = 0;
            int Quantity = 0;
            int Status = 0;
            if (dtProduct.Rows.Count > 0)
            {
                AlbumID = int.Parse(dtProduct.Compute("MAX(AlbumID)", "").ToString()) + 1;
            }
            Album pro = new Album()
            {
                AlbumID = AlbumID,
                AlbumName = AlbumName,
                ReleaseYear = ReleaseYear,
                Quantity = Quantity,
                Status = Status
            };
            frmProductDetails ProductDetail = new frmProductDetails(true, pro);
            DialogResult r = ProductDetail.ShowDialog();
            if (r == DialogResult.OK)
            {
                pro = ProductDetail.ProductAddOrEdit;
                dtProduct.Rows.Add(pro.AlbumID, pro.AlbumName,
                    pro.ReleaseYear, pro.Quantity, pro.Status);

            }
            getAllBooks();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtId.Text);
            string Name = txtName.Text;
            int Year = int.Parse(txtYear.Text);
            int Quantity = int.Parse(txtQuantity.Text);
            int Status = int.Parse(txtStatus.Text);
            Album pro = new Album()
            {
                AlbumID = ID,
                AlbumName = Name,
                ReleaseYear = Year,
                Quantity = Quantity,
                Status = Status
            };
            frmProductDetails ProductDetail = new frmProductDetails(false, pro);
            DialogResult r = ProductDetail.ShowDialog();
            if (r == DialogResult.OK)
            {
                DataRow row = dtProduct.Rows.Find(pro.AlbumID);
                row["Name"] = pro.AlbumName;
                row["Year"] = pro.ReleaseYear;
                row["Quantity"] = pro.Quantity;
                row["Status"] = pro.Status;

            }
            getAllBooks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                int a = int.Parse(txtId.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fail, try again!");
                return;
            }
            int ID = int.Parse(txtId.Text);
            if (bm.RemoveProduct(ID))
            {
                DataRow row = dtProduct.Rows.Find(ID);
                dtProduct.Rows.Remove(row);
                MessageBox.Show("Successful");
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                MessageBox.Show("Please input ID");
                return;
            }
            int ID = 0;
            try
            {
                ID = int.Parse(txtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input invalid");
            }
            Album pro = bm.FindProduct(ID);
            if (pro != null)
            {
                frmProductDetails ProductDetail = new frmProductDetails(false, pro);
                DialogResult r = ProductDetail.ShowDialog();
                if (r == DialogResult.OK)
                {
                    DataRow row = dtProduct.Rows.Find(pro.AlbumID);
                    row["AlbumName"] = pro.AlbumName;
                    row["ReleaseYear"] = pro.ReleaseYear;
                    row["Quantity"] = pro.Quantity;
                }
            }
            else
            {
                MessageBox.Show("Product not exist!");
            }
            getAllBooks();
        }
    }
}
