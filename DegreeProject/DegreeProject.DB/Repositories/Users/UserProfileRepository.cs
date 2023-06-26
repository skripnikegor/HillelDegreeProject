using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.Repositories.Users
{
    internal class UserProfileRepository : IRepository<UserProfile>
    {
        #region fields
        public DataContext DbContext { get; set; }
        #endregion
        #region methods
        public async Task<UserProfile> Add(UserProfile item)
        {
            await DbContext.Set<UserProfile>().AddAsync(item);
            return item;
        }

        public async Task Delete(UserProfile item)
        {
            DbContext.Set<UserProfile>().Remove(item);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserProfile>> GetAll()
        {
            return await DbContext.Set<UserProfile>().ToListAsync();
        }

        public async Task<UserProfile> GetById(int Id)
        {
            return await DbContext.Set<UserProfile>().FindAsync(Id);
        }

        public async Task<UserProfile> Update(UserProfile item)
        {
            DbContext.Set<UserProfile>().Update(item);
            return item;
        }
        #endregion
    }
}
