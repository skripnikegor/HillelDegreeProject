using DegreeProject.BL.Interfaces;
using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.DTO.Projects;
using Microsoft.AspNetCore.Mvc;

namespace DegreeProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandartController : Controller
    {
        private readonly IService<StandartDTO> _standartService;

        public StandartController(IService<StandartDTO> standartService)
        {
            _standartService = standartService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StandartDTO>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var standarts = await _standartService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(standarts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(StandartDTO))]
        public async Task<IActionResult> Get(int id)
        {
            if (!await _standartService.Exist(id))
                return NotFound();

            var standart = await _standartService.Get(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(standart);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StandartDTO standartCreate)
        {
            if (standartCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var standart = await _standartService.Create(standartCreate);
            return Ok(standart);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StandartDTO standartPut)
        {
            if (standartPut == null)
                return BadRequest(ModelState);

            if (!await _standartService.Exist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var standart = await _standartService.Update(id, standartPut);
            return Ok(standart);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _standartService.Exist(id))
                return NotFound();

            var result = await _standartService.Delete(id);

            return Ok(result);
        }
    }
}
