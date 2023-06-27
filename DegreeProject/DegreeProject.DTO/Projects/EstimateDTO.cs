using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DTO.Projects
{
    public class EstimateDTO
    {
        public string Name { get; set; }
        //public IEnumerable<MaterialDTO> Material { get; set; }
        //public IEnumerable<WorkDTO> Work { get; set; }
        public int? ProjectBaseId { get; set; }
    }
}
