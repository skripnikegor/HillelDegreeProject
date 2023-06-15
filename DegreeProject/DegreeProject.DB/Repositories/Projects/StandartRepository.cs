using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Models.Projects;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace DegreeProject.DB.Repositories.Projects
{
    internal class StandartRepository : IRepository<Standart>
    {
        public DataContext DbContext { get; set; }
        public async Task Add(Standart item)
        {
            await DbContext.Set<Standart>().AddAsync(item);
        }

        public async Task Delete(int Id)
        {
            var standart = await GetById(Id);
            DbContext.Set<Standart>().Remove(standart);
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
            return await DbContext.Set<Standart>().FindAsync(Id);
        }

        public async Task Update(Standart item)
        {
            DbContext.Set<Standart>().Update(item);
        }
    }
}
