using DegreeProject.DB.DataContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.Interfaces
{
    public interface IRepository <T> where T : class
    {
        public DataContext DbContext { get; set; }
        Task<T> GetById(int Id);
        Task Add(T item);
        Task Update(T item);
        Task Delete(T item);
        Task<IEnumerable<T>> GetAll();
    }
}
