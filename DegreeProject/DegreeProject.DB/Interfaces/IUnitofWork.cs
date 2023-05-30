using DegreeProject.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.Interfaces
{
    public interface IUnitofWork : IDisposable
    {
        IRepository<Customer> CustomerRepository { get; }
        void BeginTransaction();
        Task Commit();
    }
}
