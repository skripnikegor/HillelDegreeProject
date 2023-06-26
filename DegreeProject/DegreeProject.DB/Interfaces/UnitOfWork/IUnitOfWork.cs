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
        Task<T> Get(string id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Update(string id, T item);
        Task<bool> Delete(string id);
        Task<T> Add(T item);
        Task<bool> Exist(string id);
    }
}
