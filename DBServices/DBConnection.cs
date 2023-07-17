using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Student_Management.DBServices
{
    class DBConnection : IDBService
    {
        private SqlConnection connection;

        public DBConnection()
        {
            string connectionString = @"Data Source=DESKTOP-TF4EM75\MSSQLSERVER1;Initial Catalog=Hazz;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        public void openConnection()
        {
            // Open the connection.
            connection.Open();
        }

        public void closeConnection()
        {
            // Close the connection.
            connection.Close();
        }
        public int executeQuery(SqlCommand command)
        {

            // Execute the query.
            try
            {
                return command.ExecuteNonQuery(); 
            }
            catch (Exception ex)
            {
                // Handle the exception.
                MessageBox.Show(ex.Message,"Error");
                return -1;
            }
        }

        public SqlConnection getconnection()
        {
            return connection;
        }
    }
}
