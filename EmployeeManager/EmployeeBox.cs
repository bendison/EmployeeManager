using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManager
{
    public partial class EmployeeBox : Form
    {
        private List<Position> positions;
        private List<Employee> employees;
        Utility utility = new Utility();

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public EmployeeBox(List<Employee> employees, string firstName = "", string lastName = "")
        {
            InitializeComponent();
            this.employees = employees;
            Text = string.Format($"Employee: {firstName} {lastName}");
            firstNameBox.Text = firstName;
            lastNameBox.Text = lastName;
        }

        public void LoadEmployeePositions(List<Position> positions)
        {
            this.positions = positions;
        }

        private void EmployeeBox_Load(object sender, EventArgs e)
        {
            foreach (Position p in positions)
            {
                ComboboxItem item = new ComboboxItem
                {
                    Text = p.Title,
                    Value = p.ID
                };
                postionIDComboBox.Items.Add(item);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you would like to cancel adding a new employee?", "Cancel Adding Employee", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            bool check = true;

            if (utility.ValidateName(firstNameBox.Text) == false)
            {
                errorProvider.SetError(firstNameBox, "This space is left blank");
                check = false;
            }

            if (utility.ValidateName(lastNameBox.Text) == false)
            {
                errorProvider.SetError(lastNameBox, "This space is left blank");
                check = false;
            }

            if (utility.emailCheck(emailBox.Text) == false)
            {
                errorProvider.SetError(emailBox, "Invalid email");
                check = false;
            }
            if (check == true)
            {
                int id = employees.Count + 1;
                string firstName = firstNameBox.Text;
                string lastName = lastNameBox.Text;
                DateTime hireDate = hireDatePicker.Value;
                string email = emailBox.Text;
                int positionId = int.Parse((postionIDComboBox.SelectedItem as ComboboxItem).Value.ToString());
                Employee employee = new Employee(id, firstName, lastName, hireDate, positionId, email);
                employees.Add(employee);
                EmployeeManager.ToDataSet(employees);
                DialogResult result = MessageBox.Show("Employee successfully added!", "Success!", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }          
        }

        private void EmployeeBox_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
