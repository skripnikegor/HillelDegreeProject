using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        #region fields
        public DataContext DbContext { get; set; }
        #endregion

        #region methods
        public async Task Add(Customer item)
        {
            await DbContext.Set<Customer>().AddAsync(item);
        }

        public async Task Delete(Customer item)
        {
            DbContext.Set<Customer>().Remove(item);
        }

        public async Task<Customer> GetById(int Id)
        {
            return await DbContext.Set<Customer>().FindAsync(Id);
        }

        public async Task Update(Customer item)
        {
            DbContext.Set<Customer>().Update(item);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await DbContext.Set<Customer>().ToListAsync();
        }
        #endregion
    }
}
