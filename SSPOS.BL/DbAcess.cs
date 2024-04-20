using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSPOS.DL;

namespace SSPOS.BL
{
    public class DbAcess
    {
        /// <summary>
        /// Retrives the Data as DataTable format
        /// Returns the Product Data
        /// </summary>
        /// <returns></returns>
        public static DataTable RetriveAllProducts()
        {
            try
            {
                DataTable ProductTable = new DataTable();
                ProductTable = DbConnetions.RetrieveAllProducts();
                return ProductTable;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    public class GetAllProduct
    {
        // Private fields
        private int _productID;
        private string _name;
        private int _code;
        private string _uom;
        private decimal _price;
        private string _productType;
        private bool _loose;
        private string _category;
        private string _subcategory;
        private decimal _regularPrice;
        private decimal _directPrice;
        private decimal _outsidePrice;
        private string _createdBy;
        private DateTime _createdDate;
        private string _modifiedBy;
        private DateTime _modifiedDate;
        private bool _isDeleted;

        // Properties using auto-implemented properties
        public int ProductID { get => _productID; set => _productID = value; }
        public string Name { get => _name; set => _name = value; }
        public int Code { get => _code; set => _code = value; }
        public string UOM { get => _uom; set => _uom = value; }
        public decimal Price { get => _price; set => _price = value; }
        public string ProductType { get => _productType; set => _productType = value; }
        public bool Loose { get => _loose; set => _loose = value; }
        public string Category { get => _category; set => _category = value; }
        public string Subcategory { get => _subcategory; set => _subcategory = value; }
        public decimal RegularPrice { get => _regularPrice; set => _regularPrice = value; }
        public decimal DirectPrice { get => _directPrice; set => _directPrice = value; }
        public decimal OutsidePrice { get => _outsidePrice; set => _outsidePrice = value; }
        public string CreatedBy { get => _createdBy; set => _createdBy = value; }
        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
        public string ModifiedBy { get => _modifiedBy; set => _modifiedBy = value; }
        public DateTime ModifiedDate { get => _modifiedDate; set => _modifiedDate = value; }
        public bool IsDeleted { get => _isDeleted; set => _isDeleted = value; }



        public GetAllProduct()
        {
            ProductID = 0;
            Name = string.Empty;
            Code = 0;
            UOM = string.Empty;
            Price = 0;
            ProductType = string.Empty;
            Loose = false;
            Category = string.Empty;
            Subcategory = string.Empty;
            RegularPrice = 0;
            DirectPrice = 0;
            OutsidePrice = 0;
            CreatedBy = string.Empty;
            IsDeleted = false;

        }

        

    }
    



}
