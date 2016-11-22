using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager
{
    class Utility
    {
        public Utility()
        {
        }

        //Check that the employee ID is in fact an available position
        public bool ValidatePID(int id)
        {
            foreach (Position p in Position.Values)
            {
                if (p.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
