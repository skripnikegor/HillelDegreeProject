using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DTO.Projects
{
    public class ProjectDTO
    {
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal Cost { get; set; }
        //public IEnumerable<EstimateDTO> Estimate { get; set; }
        //public IEnumerable<DiagramDTO> Diagram { get; set; }
        public string ProjectStatus { get; set; }
        
    }
}
