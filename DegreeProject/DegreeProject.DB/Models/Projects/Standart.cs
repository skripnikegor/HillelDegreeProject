using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.Models.Projects
{
    internal class Standart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodeResourse { get; set; }
        public string NameResourse { get; set; }
        public string Unit { get; set; }
        public int UnitAmount { get; set; }
        public decimal LaborCostHour { get; set; }
        public decimal LaborCostMachine { get; set; }
    }
}
