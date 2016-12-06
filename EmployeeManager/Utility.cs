using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace EmployeeManager
{
    class Utility
    {
        public Utility()
        {
        }

        public bool emailCheck(string inputEmail)
        {
            if (inputEmail.Equals(""))
            {
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(inputEmail);
                return addr.Address == inputEmail;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidateName(string name)
        {
            if (name.Equals(""))
            {
                return false;
            }


            foreach (char c in name)
            {
                if (char.IsPunctuation(c))
                {
                    return false;
                }
            }
            return true;
        }

        //Check that the employee ID is in fact an available position
    }
}
