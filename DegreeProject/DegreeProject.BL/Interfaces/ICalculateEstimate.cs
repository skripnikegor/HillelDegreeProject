using DegreeProject.DTO.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.BL.Interfaces
{
    public interface ICalculateEstimate
    {
        Task<IEnumerable<MaterialDTO>> CalculateEstimate(int Id);
    }
}
