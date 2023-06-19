using DegreeProject.DB.DataContexts;
using DegreeProject.DTO.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.Interfaces
{
    public interface IUnitOfWork<T>
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();
        Task Update(int id, T item);
        Task Delete(int id);
        Task Add(T item);
    }
}
