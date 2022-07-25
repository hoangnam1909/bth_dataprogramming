using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenHoangNam1951052125
{
    class ProductDAL
    {

        private static SqlConnection conn;

        public ProductDAL()
        {
            ConnectDatabase();
        }

        private void ConnectDatabase()
        {
            string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            conn = new SqlConnection(connStr);
        }

        public DataTable loadProducts()
        {
            DataTable dataTable = new DataTable();

            string query = "Select ProductID, ProductName, UnitPrice, QuantityPerUnit, c.CategoryName, s.CompanyName, c.CategoryID, s.SupplierID "
                            + "from Products p, Categories c, Suppliers s "
                            + "where p.CategoryID = c.CategoryID and p.SupplierID = s.SupplierID";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            da.Fill(dataTable);

            return dataTable;
        }

        public DataTable loadCategories()
        {
            DataTable dataTable = new DataTable();

            string query = "Select * from Categories";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            da.Fill(dataTable);

            return dataTable;
        }

        public DataTable loadSuppliers()
        {
            DataTable dataTable = new DataTable();

            string query = "Select * from Suppliers";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            da.Fill(dataTable);

            return dataTable;
        }

        public bool add(Product product)
        {
            try
            {
                string query = String.Format("Insert Into Products (ProductName, QuantityPerUnit, UnitPrice, CategoryID, SupplierID) VALUES ('{0}', '{1}', {2}, {3}, {4})",
                                product.ProductName,
                                product.QuantityPerUnit,
                                product.UnitPrice,
                                product.CategoryID,
                                product.SupplierID);
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }

        public bool update(Product product)
        {
            try
            {
                string query = String.Format("UPDATE Products SET ProductName = N'{0}', QuantityPerUnit = '{1}', UnitPrice = {2}, CategoryID = {3}, SupplierID = {4} WHERE ProductID = {5}",
                                product.ProductName,
                                product.QuantityPerUnit,
                                product.UnitPrice,
                                product.CategoryID,
                                product.SupplierID,
                                product.ProductID);
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return true;
        }

    }
}
