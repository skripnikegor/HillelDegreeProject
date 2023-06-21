using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces.Repository;
using DegreeProject.DB.Models.Projects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.Repositories.Projects
{
    internal class DiagramRepository : IRepository<Diagram>
    {
        public DataContext DbContext { get; set; }
        public async Task<Diagram> Add(Diagram item)
        {
            await DbContext.Set<Diagram>().AddAsync(item);
            return item;
        }

        public async Task Delete(Diagram item)
        {
            DbContext.Set<Diagram>().Remove(item);
        }

        public async Task<bool> Exist(int id)
        {
            return DbContext.Set<Diagram>().Any(c => c.Id == id);
        }

        public async Task<IEnumerable<Diagram>> GetAll()
        {
            return await DbContext.Set<Diagram>().ToListAsync();
        }

        public async Task<Diagram> GetById(int Id)
        {
            return await DbContext.Set<Diagram>().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Diagram> Update(Diagram item)
        {
            DbContext.Set<Diagram>().Update(item);
            return item;
        }
    }
}
