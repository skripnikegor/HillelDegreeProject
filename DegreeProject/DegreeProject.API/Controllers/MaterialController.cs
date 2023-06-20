using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.BL.Models;
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
            if (!await _materialService.Exist(id))
                return NotFound();

            var standart = await _materialService.Get(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(standart);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MaterialDTO materialCreate)
        {
            if (materialCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var material = await _materialService.Create(materialCreate);
            return Ok(material);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MaterialDTO materialPut)
        {
            if (materialPut == null)
                return BadRequest(ModelState);

            if (!await _materialService.Exist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var material = await _materialService.Update(id, materialPut);
            return Ok(material);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _materialService.Exist(id))
                return NotFound();

            var result = await _materialService.Delete(id);
            return Ok(result);
        }
    }
}
