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
        private readonly DbContext _dbContext;

        public CustomerRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddItem(Customer item)
        {
            _dbContext.Set<Customer>().Add(item);
            _dbContext.SaveChanges();
        }

        public void DeleteItem(Customer item)
        {
            _dbContext.Set<Customer>().Remove(item);
            _dbContext.SaveChanges();
        }

        public Customer GetItemById(int Id)
        {
            return _dbContext.Set<Customer>().Find(Id);
        }

        public void UpdateItem(Customer item)
        {
            _dbContext.Set<Customer>().Update(item);
            _dbContext.SaveChanges();
        }
    }
}
