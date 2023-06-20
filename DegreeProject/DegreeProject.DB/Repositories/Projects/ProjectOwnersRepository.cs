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
    internal class ProjectOwnersRepository
    {
        public DataContext DbContext { get; set; }
        public async Task<ProjectOwner> Add(ProjectOwner item)
        {
            await DbContext.Set<ProjectOwner>().AddAsync(item);
            return item;
        }

        public async Task<ProjectOwner> Delete(ProjectOwner item)
        {
            DbContext.Set<ProjectOwner>().Remove(item);
            return item;
        }

        public async Task<bool> Exist(int id)
        {
            return DbContext.Set<ProjectOwner>().Any(c => c.Id == id);
        }

        public async Task<IEnumerable<ProjectOwner>> GetAll()
        {
            return await DbContext.Set<ProjectOwner>().ToListAsync();
        }

        public async Task<ProjectOwner> GetById(int Id)
        {
            return await DbContext.Set<ProjectOwner>().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<ProjectOwner> Update(ProjectOwner item)
        {
            DbContext.Set<ProjectOwner>().Update(item);
            return item;
        }
    }
}
