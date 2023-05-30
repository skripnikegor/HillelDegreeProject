using Microsoft.AspNetCore.Mvc;

namespace DegreeProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IService _customerService;
        public CustomerController()
        {
            
        }
    }
}
