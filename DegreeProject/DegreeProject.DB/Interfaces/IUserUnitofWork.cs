using DegreeProject.DB.Models;
using DegreeProject.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.DB.Interfaces
{
    public interface IUserUnitofWork : IDisposable
    {
        Task BeginTransaction();
        Task Commit();
        Task Save();
        Task<CustomerDTO> GetCustomer(int id);
        Task<IEnumerable<CustomerDTO>> GetAllCustomers();
        Task AddCustomer(RegisterCustomerDTO registerCustomerDTO);
    }
}
