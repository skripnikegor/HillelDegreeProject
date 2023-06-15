using DegreeProject.BL.Interfaces;
using DegreeProject.BL.NInject;
using DegreeProject.DB.Interfaces;
using DegreeProject.DB.Models;
using DegreeProject.DB.UnitOfWork;
using DegreeProject.DTO.Users;
using Ninject;


namespace DegreeProject.BL.Models
{
    //public class CustomerService : ICustomerService
    //{
    //    private readonly IUserUnitofWork _unitOfWork;

    //    public CustomerService()
    //    {
    //        var module = new Module();
    //        var kernel = new StandardKernel(module);

    //        _unitOfWork = kernel.Get<IUserUnitofWork>();
    //    }

    //    public CustomerService(IUserUnitofWork unitofWork)
    //    {
    //        _unitOfWork = unitofWork;
    //    }

    //    public async Task Create(CustomerDTO entity)
    //    {
            
             
    //    }

    //    public async Task Delete(CustomerDTO entity)
    //    {
            
    //    }

    //    public async Task<CustomerDTO> Get(int id)
    //    {
    //        return await _unitOfWork.GetCustomer(id);
    //    }

    //    public async Task<IEnumerable<CustomerDTO>> GetAll()
    //    {
    //        return await _unitOfWork.GetAllCustomers();
    //    }

    //    public async Task Update(CustomerDTO entity)
    //    {
            
    //    }
    //}
}
