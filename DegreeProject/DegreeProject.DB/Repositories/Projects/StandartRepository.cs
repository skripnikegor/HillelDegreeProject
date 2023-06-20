using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Projects;
using Microsoft.EntityFrameworkCore;


namespace DegreeProject.DB.Repositories.Projects
{
    internal class StandartRepository : IRepository<Standart>
    {
        public DataContext DbContext { get; set; }
        public async Task<Standart> Add(Standart item)
        {
            await DbContext.Set<Standart>().AddAsync(item);
            return item;
        }

        public async Task Delete(Standart item)
        {
            DbContext.Set<Standart>().Remove(item);
        }

        public async Task<bool> Exist(int id)
        {
            return DbContext.Set<Standart>().Any(c => c.Id == id);
        }

        public async Task<IEnumerable<Standart>> GetAll()
        {
            return await DbContext.Set<Standart>().ToListAsync();
        }

        public async Task<Standart> GetById(int Id)
        {
            return await DbContext.Set<Standart>().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Standart> Update(Standart item)
        {
            DbContext.Set<Standart>().Update(item);
            return item;
        }
    }
}
