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
    internal class ProjectRepository : IRepository<ProjectBase> 
    {
        public DataContext DbContext { get; set; }
        public async Task<ProjectBase> Add(ProjectBase item)
        {
            await DbContext.Set<ProjectBase>().AddAsync(item);
            return item;
        }

        public async Task Delete(ProjectBase item)
        {
            DbContext.Set<ProjectBase>().Remove(item);
            
        }

        public async Task<bool> Exist(int id)
        {
            if (await DbContext.Set<ProjectBase>().FirstAsync(c => c.Id == id) != null)
                return true;
            else return false;
        }

        public async Task<IEnumerable<ProjectBase>> GetAll()
        {
            return await DbContext.Set<ProjectBase>().ToListAsync();
        }

        public async Task<ProjectBase> GetById(int Id)
        {
            return await DbContext.Set<ProjectBase>().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<ProjectBase> Update(ProjectBase item)
        {
            DbContext.Set<ProjectBase>().Update(item);
            return item;
        }
    }
}
