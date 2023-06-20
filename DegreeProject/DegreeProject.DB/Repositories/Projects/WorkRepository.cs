using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Projects;
using Microsoft.EntityFrameworkCore;


namespace DegreeProject.DB.Repositories.Projects
{
    internal class WorkRepository : IRepository<Work>
    {
        public DataContext DbContext { get; set; }
        public async Task<Work> Add(Work item)
        {
            await DbContext.Set<Work>().AddAsync(item);
            return item;
        }

        public async Task Delete(Work item)
        {
            DbContext.Set<Work>().Remove(item);
        }

        public async Task<bool> Exist(int id)
        {
            return DbContext.Set<Work>().Any(c => c.Id == id);
        }

        public async Task<IEnumerable<Work>> GetAll()
        {
            return await DbContext.Set<Work>().ToListAsync();
        }

        public async Task<Work> GetById(int Id)
        {
            return await DbContext.Set<Work>().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Work> Update(Work item)
        {
            DbContext.Set<Work>().Update(item);
            return item;
        }
    }
}
