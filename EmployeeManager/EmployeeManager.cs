using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace EmployeeManager
{
    public partial class EmployeeManager : Form
    {
        //private DatabaseConnection db = new DatabaseConnection();
        //private MySqlDataAdapter dbDataAdapter;
        private List<Employee> employees = new List<Employee>();

        public EmployeeManager()
        {
            InitializeComponent();
        }

        private void EmployeeManager_Load(object sender, EventArgs e)
        {
            /*dbDataAdapter = new MySqlDataAdapter("select * from employees", db.connection);
            DataSet dataSet = new DataSet();
            dbDataAdapter.Fill(dataSet);
            dataGridView.DataSource = dataSet.Tables[0];
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            db.CloseConnection();*/
            string json = File.ReadAllText(Path.GetDirectoryName(Application.ExecutablePath) + "\\save.json");
            employees = JsonConvert.DeserializeObject<List<Employee>>(json);
            DataSet dataSet = ToDataSet(employees);
            dataGridView.DataSource = dataSet.Tables[0];
            



        }

        public static DataSet ToDataSet<T>(IList<T> employees)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                t.Columns.Add(propInfo.Name, propInfo.PropertyType);
            }

            //go through each property on T and add each value to the table
            foreach (T item in employees)
            {
                DataRow row = t.NewRow();
                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null);
                    //MessageBox.Show(row[propInfo.Name].ToString());
                }

                //This line was missing:
                t.Rows.Add(row);
            }


            return ds;
        }

        private void emailEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
