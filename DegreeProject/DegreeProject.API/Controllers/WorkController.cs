using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.BL.Models;
using DegreeProject.DTO.Projects;
using Microsoft.AspNetCore.Mvc;

namespace DegreeProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : Controller
    {
        private readonly IService<WorkDTO> _workService;
        public WorkController(IService<WorkDTO> workService)
        {
            _workService = workService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<WorkDTO>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var works = await _workService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(works);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(WorkDTO))]
        public async Task<IActionResult> Get(int id)
        {
            if (!await _workService.Exist(id))
                return NotFound();

            var work = await _workService.Get(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(work);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WorkDTO workCreate)
        {
            if (workCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var work = await _workService.Create(workCreate);
            return Ok(work);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] WorkDTO workPut)
        {
            if (workPut == null)
                return BadRequest(ModelState);

            if (!await _workService.Exist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var standart = await _workService.Update(id, workPut);
            return Ok(standart);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _workService.Exist(id))
                return NotFound();

            var result = await _workService.Delete(id);

            return Ok(result);
        }

    }
}
