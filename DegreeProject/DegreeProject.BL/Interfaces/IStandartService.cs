using DegreeProject.DTO.Projects;
using DegreeProject.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.BL.Interfaces
{
    public interface IStandartService
    {
        Task<IEnumerable<StandartDTO>> GetAll();
        Task<StandartDTO> Get(int id);
        Task Create(StandartDTO entity);
        Task Update(int id, StandartDTO entity);
        Task Delete(int id, StandartDTO entity);
    }
}
