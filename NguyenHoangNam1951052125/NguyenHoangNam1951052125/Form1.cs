using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace NguyenHoangNam1951052125
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductBUS bus = new ProductBUS();

        private void Form1_Load(object sender, EventArgs e)
        {
            bus.loadProduct(gvSanPham);
            bus.loadCategory(cbLoaiSP);
            bus.loadSuppliers(cbNCC);
        }

        private void AddProduct()
        {
            Product product = new Product();
            product.ProductName = txtTenSP.Text.ToString().Trim();
            product.QuantityPerUnit = txtSoLuong.Text.ToString().Trim();
            product.UnitPrice = double.Parse(txtDonGia.Text);
            product.CategoryID = Int32.Parse(cbLoaiSP.SelectedValue.ToString());
            product.SupplierID = Int32.Parse(cbNCC.SelectedValue.ToString());

            bus.add(product);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text.Trim() == "" ||  txtDonGia.Text.Trim() == "" || txtSoLuong.Text.Trim() == "")
            {
                MessageBox.Show("Kiem tra lai ho cai");
            } else
            {
                AddProduct();
                Form1_Load(sender, e);
            }
        }

        private void gvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < gvSanPham.Rows.Count)
                {
                    txtID.Text = gvSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtTenSP.Text = gvSanPham.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtDonGia.Text = gvSanPham.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                    txtSoLuong.Text = gvSanPham.Rows[e.RowIndex].Cells["QuantityPerUnit"].Value.ToString();
                    cbLoaiSP.SelectedValue = int.Parse(gvSanPham.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString());
                    cbNCC.SelectedValue = int.Parse(gvSanPham.Rows[e.RowIndex].Cells["SupplierID"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product();
                product.ProductID = int.Parse(txtID.Text);
                product.ProductName = txtTenSP.Text;
                product.QuantityPerUnit = txtSoLuong.Text;
                product.UnitPrice = double.Parse(txtDonGia.Text);
                product.CategoryID = int.Parse(cbLoaiSP.SelectedValue.ToString());
                product.SupplierID = int.Parse(cbNCC.SelectedValue.ToString());

                bus.update(product);
                Form1_Load(sender, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
