using DegreeProject.BL.Interfaces;
using DegreeProject.BL.NInject;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Models;
using DegreeProject.DB.UnitOfWork;
using Ninject;


namespace DegreeProject.BL.Models
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitofWork _unitOfWork;

        public CustomerService()
        {
            var module = new Module();
            var kernel = new StandardKernel(module);

            _unitOfWork = kernel.Get<UnitOfWork>();
        }

        public CustomerService(IUnitofWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }

        public async Task Create(Customer entity)
        {
            
            await _unitOfWork.CustomerRepository.Add(entity);
            await _unitOfWork.Commit();
        }

        public async Task Delete(Customer entity)
        {
            await _unitOfWork.CustomerRepository.Delete(entity);
        }

        public async Task<Customer> Get(int id)
        {
            return await _unitOfWork.CustomerRepository.GetById(id);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _unitOfWork.CustomerRepository.GetAll();
        }

        public async Task Update(Customer entity)
        {
            await _unitOfWork.CustomerRepository.Update(entity);
            await _unitOfWork.Commit();
        }
    }
}
