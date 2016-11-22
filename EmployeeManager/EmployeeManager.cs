using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EmployeeManager
{
    public partial class EmployeeManager : Form
    {

        private DatabaseConnection db = new DatabaseConnection();

        public EmployeeManager()
        {
            InitializeComponent();
            MessageBox.Show(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\config.json");
        }
    }
}
