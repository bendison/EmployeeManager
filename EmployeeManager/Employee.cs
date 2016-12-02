using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManager
{    
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public int Position { get; set; }

        public Employee(int id, string firstName, string lastName, DateTime hireDate, int position)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.HireDate = hireDate;
            this.Position = position;
        }        
    }  
}
