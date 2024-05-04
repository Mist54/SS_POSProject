using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SSPOS.DL
{
    public class DbConnetions
    {
        /// <summary>
        /// Gets the connection string from the App.config file 
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return connectionString;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Retrive all the Data from Product table 
        /// </summary>
        /// <returns></returns>
        public static DataTable RetrieveAllProducts()
        {
            string connectionString = GetConnectionString();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Product_RetriveAll", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    _ = adapter.Fill(dataTable);

                    // Check if DataTable has rows
                    if (dataTable.Rows.Count == 0)
                    {
                        throw new Exception("No data returned from the stored procedure.");
                    }

                    return dataTable;
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Exception: " + sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Retrives all the Table name from the TableList 
        /// </summary>
        /// <returns></returns>
        public static DataTable RetrieveAllTableName()
        {
            string connectionString = GetConnectionString();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetAllTableName", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    _ = adapter.Fill(dataTable);

                    // Check if DataTable has rows
                    if (dataTable.Rows.Count == 0)
                    {
                        throw new Exception("No data returned from the stored procedure.");
                    }

                    return dataTable;
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Exception: " + sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                throw;
            }
        }


    }

}
