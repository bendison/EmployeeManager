using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager
{
    class Database
    {
        public Database()
        {
        }

        public void AddEmployee(List<Employee> employees, Employee e)
        {
            employees.Add(e);
        }
    }
}
