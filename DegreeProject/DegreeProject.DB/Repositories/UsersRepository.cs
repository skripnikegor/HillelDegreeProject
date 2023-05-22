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
    public class UsersRepository<T> : IRepository<T> where T : UserBase
    {
        #region fields
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        #endregion
        public UsersRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        #region methods
        public async Task Add(T item)
        {
            await _dbSet.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T item)
        {
            _dbSet.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task Update(T item)
        {
            _dbSet.Update(item);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
