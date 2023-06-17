using DegreeProject.BL.Interfaces;
using DegreeProject.DTO.Projects;
using Microsoft.AspNetCore.Mvc;

namespace DegreeProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandartController : Controller
    {
        private readonly IStandartService _standartService;

        public StandartController(IStandartService standartService)
        {
            _standartService = standartService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StandartDTO>))]
        public async Task<IActionResult> GetAsync()
        {
            var standarts = await _standartService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(standarts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(StandartDTO))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(int id)
        {
            var standart = await _standartService.Get(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //TODO: добавить проверку на null
            return Ok(standart);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StandartDTO standartCreate)
        {
            await _standartService.Create(standartCreate);
            return Ok(standartCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StandartDTO standartPut)
        {
            await _standartService.Update(id, standartPut);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id,  StandartDTO standart)
        {
            await _standartService.Delete(id, standart);
            return Ok();
        }
    }
}
