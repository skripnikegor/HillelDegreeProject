using DegreeProject.DB.Models;
using DegreeProject.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.BL.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAll();
        Task<CustomerDTO> Get(int id);
        Task Create(CustomerDTO entity);
        Task Update(CustomerDTO entity);
        Task Delete(CustomerDTO entity);
    }
}
