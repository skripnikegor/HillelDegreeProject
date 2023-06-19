using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Models;
using DegreeProject.DB.NInject;
using DegreeProject.DB.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.UnitOfWork
{
    public abstract class UnitOfWorkBase 
    {
        
        private IDbContextTransaction _transaction;

        private bool _disposed;

       
        #region IUnitOfWork methods
        public async Task BeginTransaction(DataContext _dbContext)
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public async Task Commit()
        {
            _transaction.Commit();
        }

        //public void Dispose()
        //{
        //    Dispose(, true);
        //    GC.SuppressFinalize(this);
        //}

        public async Task Save(DataContext _dbContext)
        {
            _dbContext.SaveChanges();
        }
        protected virtual void Dispose(DataContext _dbContext, bool disposing)
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
        #endregion
    }
}
