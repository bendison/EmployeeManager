using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager
{
    class Position
    {
        public static readonly Position Trainee = new Position("Trainee", 0);
        public static readonly Position Janitor = new Position("Janitor", 1);
        public static readonly Position It = new Position("It", 2);
        public static readonly Position Maintenance = new Position("Maintenance", 3);
        public static readonly Position Chemist = new Position("Chemist", 4);
        public static readonly Position LabTech = new Position("LabTech", 5);
        public static readonly Position Hr = new Position("Hr", 6);
        public static readonly Position Supervisor = new Position("Supervisor", 7);
        public static readonly Position PlantOfficer = new Position("PlantOfficer", 8);

        public static IEnumerable<Position> Values = new List<Position>() { Trainee, Janitor, It, Maintenance, Chemist, LabTech, Hr, Supervisor, PlantOfficer};

        private readonly string name;
        private readonly int id;
        private readonly string dBColumn;

        Position(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public string Name { get { return name; } }
        public int Id { get { return id; } }
    }
}
