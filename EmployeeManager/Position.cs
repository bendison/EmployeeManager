using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace EmployeeManager
{
    class Position
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public Position(int id, string title)
        {
            ID = id;
            Title = title;
        }
    }
}
