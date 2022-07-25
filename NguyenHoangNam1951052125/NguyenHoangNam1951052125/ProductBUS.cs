using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenHoangNam1951052125
{
    class ProductBUS
    {

        ProductDAL dal = new ProductDAL();

        public void loadProduct(DataGridView dataGridView)
        {
            dataGridView.DataSource = dal.loadProducts();
        }

        public void loadCategory(ComboBox cbb)
        {
            cbb.DataSource = dal.loadCategories();
            cbb.DisplayMember = "CategoryName";
            cbb.ValueMember = "CategoryID";
        }

        public void loadSuppliers(ComboBox cbb)
        {
            cbb.DataSource = dal.loadSuppliers();
            cbb.DisplayMember = "CompanyName";
            cbb.ValueMember = "SupplierID";
        }

        public bool add(Product product)
        {
            return dal.add(product);
        }

        public bool update(Product product)
        {
            return dal.update(product);
        }

    }
}
