using DegreeProject.BL.Interfaces;
using DegreeProject.BL.Models;
using DegreeProject.DTO.Users;
using Microsoft.AspNetCore.Mvc;

namespace DegreeProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var customers = await _customerService.GetAll();
            return Ok(customers);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerService.Get(id);
            return Ok(customer);
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(CustomerDTO CustomerCreate)



    }
}
