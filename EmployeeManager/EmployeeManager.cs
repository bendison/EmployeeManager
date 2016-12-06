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
using Newtonsoft.Json;

namespace EmployeeManager
{
    public partial class EmployeeManager : Form
    {
        public List<Employee> employees = new List<Employee>();
        private List<Position> positions = new List<Position>();
        Utility util = new Utility();

        public EmployeeManager()
        {
            InitializeComponent();
        }

        private void EmployeeManager_Load(object sender, EventArgs e)
        {
            string json = File.ReadAllText(Path.GetDirectoryName(Application.ExecutablePath) + "\\save.json");
            employees = JsonConvert.DeserializeObject<List<Employee>>(json);
            string p = File.ReadAllText(Path.GetDirectoryName(Application.ExecutablePath) + "\\positions.json");
            positions = JsonConvert.DeserializeObject<List<Position>>(p);
            DataSet dataSet = ToDataSet(employees);
            dataGridView.DataSource = dataSet.Tables[0];
        }

        public static DataSet ToDataSet<T>(IList<T> employees)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            
            foreach (var propInfo in elementType.GetProperties())
            {
                t.Columns.Add(propInfo.Name, propInfo.PropertyType);
            }
            
            foreach (T item in employees)
            {
                DataRow row = t.NewRow();
                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null);
                }

                t.Rows.Add(row);
            }
            return ds;
        }        

        private void emailEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string startupPath = Environment.CurrentDirectory;
            //email.sendEmail(null);
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {              
            EmployeeBox employeeBox = new EmployeeBox(employees);
            employeeBox.LoadEmployeePositions(positions);
            employeeBox.ShowDialog();
            dataGridView.Refresh();
        }

        private void editEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count != 0)
            {
                DataGridViewRow currentRow = dataGridView.CurrentRow;
                string firstName = currentRow.Cells[1].Value.ToString();
                string lastName = currentRow.Cells[2].Value.ToString();
                EmployeeBox employeeBox = new EmployeeBox(employees, firstName, lastName);
                employeeBox.LoadEmployeePositions(positions);
                employeeBox.ShowDialog();
                return;
            }
            MessageBox.Show("You must have an employee selected");
        }
       
    }
}
