using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Mail;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace EmployeeManager
{
    class Email
    {
        public Email() { }

        public void sendEmail(/*string email*/string name)
        {
            //string logPath = startPath + "\\log.txt";
            
            //string logPath = @"C:\Users\mirce\Desktop\log.txt";
            Outlook.Application app = new Outlook.Application();
            Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "test";
            mailItem.To = "andreimpana@gmail.com";
            mailItem.Body = "Dear " + /*First name from data entry*/ "";
            mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
            mailItem.Display(false);
        }
    }
}
