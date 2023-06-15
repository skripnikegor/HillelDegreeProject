using DegreeProject.DB.Models.Projects;
using DegreeProject.DTO.Projects;
using DegreeProject.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.Interfaces
{
    public interface IProjectUnitOfWork : IDisposable
    {
        Task BeginTransaction();
        Task Commit();
        Task Save();
        Task<StandartDTO> GetStandart(int id);
        Task<IEnumerable<StandartDTO>> GetStandarts();
        Task UpdateStandart(int id, StandartDTO item);
        Task DeleteStandart(int Id);
        Task AddStandart(StandartDTO item);

    }
}
