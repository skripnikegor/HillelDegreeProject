using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.Interfaces
{
    public interface IUnitofWork : IDisposable
    {
        IRepository GetRepository<TEntity, IRepository>()
            where TEntity : class
            where IRepository : IRepository<IEntyty>, new();
        Task Commit();
        Task Rollback();
    }
}
