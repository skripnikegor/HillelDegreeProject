using DegreeProject.DB.DataContexts;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Models;
using DegreeProject.DB.NInject;
using DegreeProject.DTO.Users;
using Microsoft.EntityFrameworkCore.Storage;
using Ninject;


namespace DegreeProject.DB.UnitOfWork
{
    public class UserUnitOfWork : IUserUnitofWork
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<UserProfile> _userProfileRepository;
        private readonly DataContext _dbContext;
        private IDbContextTransaction _transaction;

        private bool _disposed;

        public UserUnitOfWork()
        {
            var module = new UserModule();
            var kernel = new StandardKernel(module);

            _dbContext = kernel.Get<DataContext>();
            _customerRepository = kernel.Get<IRepository<Customer>>();
            _userProfileRepository = kernel.Get<IRepository<UserProfile>>();

            _customerRepository.DbContext = _dbContext;
            _userProfileRepository.DbContext = _dbContext;
        }

        #region IUnitOfWork methods
        public async  Task BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public async Task Commit()
        {
            _transaction.Commit();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            _dbContext.SaveChanges();
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
        #endregion

        #region Repositories methods
        public async Task AddCustomer(RegisterCustomerDTO registerCustomerDTO)
        {

        }

        public async Task<CustomerDTO> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetById(id);
            return new CustomerDTO { Name = $"{customer.Name}", 
                UserProfileId = customer.UserProfileId, 
                UserProfile = new UserProfileDTO { Email = customer.UserProfile.Email, 
                    PhoneNumber = customer.UserProfile.PhoneNumber, 
                    ProfileImage = customer.UserProfile.ProfileImage } };
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAll();
            return customers.Select(customer => new CustomerDTO { Name = $"{customer.Name}", UserProfileId = customer.UserProfileId }).ToList();
        }
        #endregion
    }
}
