using DegreeProject.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.Interfaces.UnitOfWork
{
    public interface IUserUnitOfWork<T>
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();
        Task Update(int id, T item);
        Task Delete(int id);
        Task Add(RegisterUserDTO item);
        Task Exist(int id);
    }
}
