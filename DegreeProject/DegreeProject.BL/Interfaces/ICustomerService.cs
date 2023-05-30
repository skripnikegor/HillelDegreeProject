using DegreeProject.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.BL.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> Get(int id);
        Task Create(Customer entity);
        Task Update(Customer entity);
        Task Delete(Customer entity);
    }
}
