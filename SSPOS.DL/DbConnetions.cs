using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace SSPOS.DL
{
    public class DbConnetions
    {
        private string connectionString;
        public DbConnetions()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        }

        public SqlConnection GetSqlConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                connection.Dispose();
                throw ex; // Re-throw the exception after handling
            }
            return connection;
        }
    }
}
