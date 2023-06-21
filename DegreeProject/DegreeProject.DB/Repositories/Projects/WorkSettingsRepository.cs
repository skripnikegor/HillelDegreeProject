using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Projects;
using Microsoft.EntityFrameworkCore;

namespace DegreeProject.DB.Repositories.Projects
{
    internal class WorkSettingsRepository : IRepository<WorksSettings>
    {
        public DataContext DbContext { get; set; }
        public async Task<WorksSettings> Add(WorksSettings item)
        {
            var result = await DbContext.Set<WorksSettings>().AddAsync(item);
            return result.Entity;
        }

        public async Task Delete(WorksSettings item)
        {
            DbContext.Set<WorksSettings>().Remove(item);
        }

        public async Task<bool> Exist(int id)
        {
            return DbContext.Set<WorksSettings>().Any(c => c.Id == id);
        }

        public async Task<IEnumerable<WorksSettings>> GetAll()
        {
            return await DbContext.Set<WorksSettings>().ToListAsync();
        }

        public async Task<WorksSettings> GetById(int Id)
        {
            return await DbContext.Set<WorksSettings>().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<WorksSettings> Update(WorksSettings item)
        {
            var result = DbContext.Set<WorksSettings>().Update(item);
            return result.Entity;
        }
    }
}
