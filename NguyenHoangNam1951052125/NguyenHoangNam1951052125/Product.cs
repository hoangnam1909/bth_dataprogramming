using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenHoangNam1951052125
{
    class Product
    {

        private int productID;
        private string productName;
        private string quantityPerUnit;
        private double unitPrice;
        private int categoryID;
        private int supplierID;

        public Product()
        {
        }

        public Product(int productID, string productName, string quantityPerUnit, double unitPrice, int categoryID, int supplierID)
        {
            this.productID = productID;
            this.productName = productName;
            this.quantityPerUnit = quantityPerUnit;
            this.unitPrice = unitPrice;
            this.categoryID = categoryID;
            this.supplierID = supplierID;
        }

        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string QuantityPerUnit { get => quantityPerUnit; set => quantityPerUnit = value; }
        public double UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public int SupplierID { get => supplierID; set => supplierID = value; }
    }
}
