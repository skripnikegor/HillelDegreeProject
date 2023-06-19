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
    internal class EstimateRepository : IRepository<Estimate>
    {
        public DataContext DbContext { get; set; }
        public async Task<Estimate> Add(Estimate item)
        {
            await DbContext.Set<Estimate>().AddAsync(item);
            return item;
        }

        public async Task<Estimate> Delete(Estimate item)
        {
             DbContext.Set<Estimate>().Remove(item);
            return item;
        }

        public async Task<bool> Exist(int id)
        {
            return DbContext.Set<Estimate>().Any(c => c.Id == id);
        }

        public async Task<IEnumerable<Estimate>> GetAll()
        {
            return await DbContext.Set<Estimate>().ToListAsync();
        }

        public async Task<Estimate> GetById(int Id)
        {
            return await DbContext.Set<Estimate>().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Estimate> Update(Estimate item)
        {
            DbContext.Set<Estimate>().Update(item);
            return item;
        }
    }
}
