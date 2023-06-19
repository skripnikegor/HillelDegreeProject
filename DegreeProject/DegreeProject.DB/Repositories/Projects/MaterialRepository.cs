using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Projects;
using Microsoft.EntityFrameworkCore;

namespace DegreeProject.DB.Repositories.Projects
{
    internal class MaterialRepository : IRepository<Material>
    {
        public DataContext DbContext { get; set; }

        public async Task<Material> Add(Material item)
        {
            await DbContext.Set<Material>().AddAsync(item);
            return item;
        }

        public async Task<Material> Delete(Material item)
        {
            DbContext.Set<Material>().Remove(item);
            return item;
        }

        public async Task<bool> Exist(int id)
        {
            return DbContext.Set<Material>().Any(c => c.Id == id);
        }

        public async Task<IEnumerable<Material>> GetAll()
        {
            return await DbContext.Set<Material>().ToListAsync();
        }

        public async Task<Material> GetById(int Id)
        {
            return await DbContext.Set<Material>().FindAsync(Id);
        }

        public async Task<Material> Update(Material item)
        {
             DbContext.Set<Material>().Update(item);
             return item;
        }
    }
}
