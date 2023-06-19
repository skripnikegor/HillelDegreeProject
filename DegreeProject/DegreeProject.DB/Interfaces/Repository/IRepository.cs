using DegreeProject.DB.DataContexts;
using DegreeProject.DTO.Projects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.Interfaces.Repository
{
    internal interface IRepository <T> where T : class
    {
        internal DataContext DbContext { get; set; }
        Task<T> GetById(int Id);
        Task<T> Add(T item);
        Task<T> Update(T item);
        Task<bool> Delete(T item);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Exist(int id);
    }
}
