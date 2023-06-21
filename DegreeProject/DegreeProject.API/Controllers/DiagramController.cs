using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.BL.Models;
using DegreeProject.DTO.Projects;
using Microsoft.AspNetCore.Mvc;

namespace DegreeProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagramController : Controller
    {
        private readonly IService<DiagramDTO> _diagramService;
        public DiagramController(IService<DiagramDTO> diagramService)
        {
            _diagramService = diagramService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<WorkDTO>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var works = await _diagramService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(works);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(DiagramDTO))]
        public async Task<IActionResult> Get(int id)
        {
            if (!await _diagramService.Exist(id))
                return NotFound();

            var work = await _diagramService.Get(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(work);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DiagramDTO diagram)
        {
            if (diagram == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _diagramService.Create(diagram);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DiagramDTO diagramPut)
        {
            if (diagramPut == null)
                return BadRequest(ModelState);

            if (!await _diagramService.Exist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var standart = await _diagramService.Update(id, diagramPut);
            return Ok(standart);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _diagramService.Exist(id))
                return NotFound();

            var result = await _diagramService.Delete(id);

            return Ok(result);
        }

    }
}
