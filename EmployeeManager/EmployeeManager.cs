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
        private MySqlDataAdapter dbDataAdapter;

        public EmployeeManager()
        {
            InitializeComponent();
        }

        private void EmployeeManager_Load(object sender, EventArgs e)
        {
            dbDataAdapter = new MySqlDataAdapter("select * from employees", db.connection);
            DataSet dataSet = new DataSet();
            dbDataAdapter.Fill(dataSet);
            dataGridView.DataSource = dataSet.Tables[0];
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            db.CloseConnection();
        }

        private void emailEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
