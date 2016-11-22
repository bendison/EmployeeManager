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
        private MySqlConnection db;
        private string connectionString;
        private Auth auth;

        public DatabaseConnection()
        {
            RetrieveConnectionInformation();
                       
            connectionString = $"server={auth.server};uid={auth.username};" + $"pwd={auth.password};database={auth.database};";
            try
            {
                db = new MySqlConnection(connectionString);
                db.Open();
                MessageBox.Show("Connection established successfully.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Unable to establish a connection to the employee database. Please contact an administrator.\nError: {ex.Message}");
            }
        }

        private void RetrieveConnectionInformation()
        {
            try
            {
                auth = JsonConvert.DeserializeObject<Auth>(File.ReadAllText(@Path.GetDirectoryName(Application.ExecutablePath) + "\\config.json"));
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
    }
}
