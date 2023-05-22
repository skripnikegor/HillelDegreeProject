using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.Interfaces
{
    public interface IRepository <T>
    {
        Task<T> GetById(int Id);
        Task Add(T item);
        Task Update(T item);
        Task Delete(T item);
    }
}
