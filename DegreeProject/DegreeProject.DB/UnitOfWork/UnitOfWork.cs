using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Models;
using DegreeProject.DB.NInject;
using DegreeProject.DB.Repositories;
using Microsoft.EntityFrameworkCore;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.UnitOfWork
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly DataContext _dbContext;

        private bool _disposed;

        public UnitOfWork()
        {
            var module = new Module();
            var kernel = new StandardKernel(module);

            _dbContext = kernel.Get<DataContext>();
            _customerRepository = kernel.Get<CustomerRepository>();
            _customerRepository.DbContext = _dbContext;
        }

        public UnitOfWork(DataContext dbContext, IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
            _dbContext = dbContext;
            _customerRepository.DbContext = dbContext;
        }

        public IRepository<Customer> CustomerRepository => _customerRepository;


        public void BeginTransaction()
        {
            _dbContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext?.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
