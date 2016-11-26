using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EmployeeManager
{
    class DatabaseConnection
    {
        //Add prepared statement support on server side

        public MySqlConnection connection;
        private string connectionString;
        private Auth auth;

        public DatabaseConnection()
        {
            RetrieveConnectionInformation();

            connectionString = $"server={auth.server};uid={auth.username};" +
                               $"pwd={auth.password};database={auth.database};";
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                MessageBox.Show("Connection established successfully.");
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Please contact the administrator.");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid database username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
            }
        }

        private void RetrieveConnectionInformation()
        {
            try
            {
                auth =
                    JsonConvert.DeserializeObject<Auth>(
                        File.ReadAllText(@Path.GetDirectoryName(Application.ExecutablePath) + "\\config.json"));
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected class Auth
        {
            public string server { get; set; }
            public string database { get; set; }
            public string username { get; set; }
            public string password { get; set; }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Unable to properly close connection to the database. Please contact an administrator.");
                return false;                
            }
        }
    }
}
