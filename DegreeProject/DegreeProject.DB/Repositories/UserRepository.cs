using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Users;
using Microsoft.EntityFrameworkCore;


namespace DegreeProject.DB.Repositories
{
    internal class UserRepository : IRepository<UserBase>
    {
        #region fields
        public DataContext DbContext { get; set; }
        #endregion

        #region methods
        public async Task Add(UserBase item)
        {
            await DbContext.Set<UserBase>().AddAsync(item);
        }

        public async Task Delete(UserBase item)
        {
            DbContext.Set<UserBase>().Remove(item);
        }

        public async Task<UserBase> GetById(int id)
        {
            return await DbContext.Set<UserBase>().FindAsync(id);
        }

        public async Task Update(UserBase item)
        {
            DbContext.Set<UserBase>().Update(item);
        }

        public async Task<IEnumerable<UserBase>> GetAll()
        {
            return await DbContext.Set<UserBase>().ToListAsync();
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
