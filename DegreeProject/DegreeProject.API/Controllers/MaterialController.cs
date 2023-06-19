using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.DTO.Projects;
using Microsoft.AspNetCore.Mvc;

namespace DegreeProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : Controller
    {
        private readonly IService<MaterialDTO> _materialService;

        public MaterialController(IService<MaterialDTO> materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MaterialDTO>))]
        public async Task<IActionResult> GetAsync()
        {
            var standarts = await _materialService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(standarts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(MaterialDTO))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(int id)
        {
            var standart = await _materialService.Get(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //TODO: добавить проверку на null
            return Ok(standart);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MaterialDTO material)
        {
            await _materialService.Create(material);
            return Ok(material);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MaterialDTO material)
        {
            await _materialService.Update(id, material);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _materialService.Delete(id);
            return Ok();
        }
    }
}
