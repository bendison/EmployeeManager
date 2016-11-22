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
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime hireDate { get; set; }
        public int position { get; set; }

        public Employee(int id, string firstName, string lastName, DateTime hireDate, int position)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.hireDate = hireDate;
            this.position = position;
        }
    }
       
            
       
}
