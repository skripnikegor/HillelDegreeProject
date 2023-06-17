using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DTO.Projects
{
    public class StandartDTO
    {
        public string Name { get; set; }
        public string CodeResourse { get; set; }
        public string NameResourse { get; set; }
        public string Unit { get; set; }
        public int UnitAmount { get; set; }
        public double LaborCostHour { get; set; }
        public double LaborCostMachine { get; set; }
    }
}
