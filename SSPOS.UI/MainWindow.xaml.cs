using MahApps.Metro.Controls;
using System.Windows;
using SSPOS.BL;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Timers;

namespace SSPOS.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        //Public fields
        public string SearchStorage = "";
        public Timer  searchTimer;


        public MainWindow()
        {
            InitializeComponent();
            BindItemListGrid(); //Binds the Item list Grid
            getTableNames();
        }

        private static List<GetAllProduct> RetriveAllProducts()
        {
            try
            {
                List<GetAllProduct> ProductList = new List<GetAllProduct>();

                DataTable productTable = DbAcess.RetriveAllProducts();
                foreach (DataRow row in productTable.Rows)
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
            if(e.Key == System.Windows.Input.Key.F6)
            {
                SearchStorage = "";
            }
            string pressedKey = e.Key.ToString().ToLower().Trim();
            SearchStorage += pressedKey;
            int selectedIndex = 0;
            bool flag = false;
            List<GetAllProduct> ProductList = RetriveAllProducts();
            // Filter ProductList based on pressedKey with case sensitivity on the Name property only
            List<GetAllProduct> filteredProducts = ProductList.Where(product => product.Name.ToLower().StartsWith(SearchStorage.ToLower())).ToList();
            if (filteredProducts != null && filteredProducts.Count != 0)
            {
                foreach (GetAllProduct product in ProductList)
                {
                    foreach(GetAllProduct filteredProduct in filteredProducts)
                    {
                        if(product.Code == filteredProduct.Code)
                        {
                            ItemListGrid.SelectedIndex = selectedIndex;
                            ItemListGrid.ScrollIntoView(ItemListGrid.Items[selectedIndex]);
                            flag = true;
                            break;
                        }
                       
                    }
                    if(flag == true)
                    {
                       
                        break;
                    }
                    selectedIndex++;
                    
                }
               
            }
            else
            {
                SearchStorage = "";
            }

            // Set up timer to clear SearchStorage after 5 seconds
            if (searchTimer != null)
            {
                searchTimer.Stop();
                searchTimer.Dispose();
            }

            searchTimer = new System.Timers.Timer
            {
                Interval = 5000 // 5 seconds
            };
            searchTimer.Elapsed += (s, ev) => { SearchStorage = ""; };
            searchTimer.AutoReset = false; // Only fire once
            searchTimer.Enabled = true;

        }

        private void ItemListGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            if (!int.TryParse(e.Text, out _))
            {
                e.Handled = true;
            }



        }

        private void txtCode_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                int selectedIndex = 0;
                bool flag = false;
                List<GetAllProduct> ProductList = RetriveAllProducts();
                // Filter ProductList based on pressedKey with case sensitivity on the Name property only
                List<GetAllProduct> filteredProducts = ProductList.Where(product => product.Code == Convert.ToInt32(txtCode.Text)).ToList();
                if (filteredProducts != null && filteredProducts.Count != 0)
                {
                    foreach (GetAllProduct product in ProductList)
                    {
                        foreach (GetAllProduct filteredProduct in filteredProducts)
                        {
                            if (product.Code == filteredProduct.Code)
                            {
                                ItemListGrid.SelectedIndex = selectedIndex;
                                ItemListGrid.ScrollIntoView(ItemListGrid.Items[selectedIndex]);
                                flag = true;
                                break;
                            }

                        }
                        if (flag == true)
                        {
                            break;
                        }
                        selectedIndex++;

                    }

                }
            }

        }
        private void getTableNames()
        {
            List<string> tableNameList = DbAcess.RetrieveAllTableName();
            if (tableNameList != null && tableNameList.Count > 0)
            {
                foreach (string tableName in tableNameList)
                {
                    dropdownTableType.Items.Add(new ComboBoxItem { Content = tableName });
                }
            }
        }
    }
}

