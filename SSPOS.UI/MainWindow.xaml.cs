using MahApps.Metro.Controls;
using System.Windows;
using SSPOS.BL;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace SSPOS.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public string SearchStorage = "";
        public MainWindow()
        {
            InitializeComponent();
            BindItemListGrid();
        }

        private static List<GetAllProduct> RetriveAllProducts()
        {
            try
            {
                List<GetAllProduct> ProductList = new List<GetAllProduct>();

                DataTable productTable = DbAcess.RetriveAllProducts();
                foreach(DataRow row in productTable.Rows)
                {
                    GetAllProduct getAllProduct = new GetAllProduct();
                    getAllProduct.ProductID = Convert.ToInt32(row["ProductID"]);
                    getAllProduct.Name = row["Name"].ToString();
                    getAllProduct.Code = Convert.ToInt32(row["Code"]);
                    getAllProduct.UOM = row["UOM"].ToString();
                    getAllProduct.Price = Convert.ToDecimal(row["Price"]);
                    getAllProduct.ProductType = row["ProductType"].ToString();
                    getAllProduct.Loose = Convert.ToBoolean(row["Loose"]);
                    getAllProduct.Category = row["Category"].ToString();
                    getAllProduct.Subcategory = row["Subcategory"].ToString();
                    getAllProduct.RegularPrice = Convert.ToDecimal(row["RegularPrice"]);
                    getAllProduct.OutsidePrice = Convert.ToDecimal(row["OutsidePrice"]);
                    getAllProduct.CreatedBy = row["CreatedBy"].ToString();
                    getAllProduct.CreatedDate = Convert.ToDateTime(row["CreatedDate"]);
                    getAllProduct.ModifiedBy = row["ModifiedBy"].ToString();
                    getAllProduct.ModifiedDate = Convert.ToDateTime(row["ModifiedDate"]);
                    getAllProduct.IsDeleted = Convert.ToBoolean(row["IsDeleted"]);

                    ProductList.Add(getAllProduct);
                }

                return ProductList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindItemListGrid()
        {
            List<GetAllProduct> ProductList = RetriveAllProducts();
            foreach (GetAllProduct product in ProductList)
            {
                ItemListGrid.Items.Add(product);
            }


        }

        private void ItemListGrid_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string pressedKey = e.Key.ToString().ToLower().Trim();
            SearchStorage += pressedKey;
            ItemListGrid.Items.Clear();//Clears the Previous records 
            List<GetAllProduct> ProductList = RetriveAllProducts();
            // Filter ProductList based on pressedKey with case sensitivity on the Name property only
            ProductList = ProductList.Where(product =>product.Name.ToLower().StartsWith(SearchStorage.ToLower())).ToList();
            if (ProductList != null && ProductList.Count != 0)
            {
                foreach (GetAllProduct product in ProductList)
                {
                    ItemListGrid.Items.Add(product);
                }
                ItemListGrid.Focus();
                ItemListGrid.SelectedIndex = 0;
                ItemListGrid.ScrollIntoView(ItemListGrid.Items[0]);

            }
            else
            {
                BindItemListGrid();
                SearchStorage = "";
            }

        }

        private void ItemListGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ItemListGrid.SelectedItem != null)
            {
                GetAllProduct selectedProduct = (GetAllProduct)ItemListGrid.SelectedItem;
                txtCode.Text = selectedProduct.Code.ToString().Trim();
                txtQty.Text = "1";
                
            }
        }

        

        private void txtQty_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true; 
            }
        }

        private void txtCode_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
