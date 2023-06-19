using DegreeProject.BL.Interfaces;
using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.BL.Models;
using DegreeProject.DTO.Users;
using Microsoft.AspNetCore.Mvc;

namespace DegreeProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IService<UserDTO> _userService;

        public UserController(IService<UserDTO> userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var customers = await _userService.GetAll();
            return Ok(customers);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _userService.Get(id);
            return Ok(customer);
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(CustomerDTO CustomerCreate)



    }
}
