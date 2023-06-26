using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.DTO.Projects;
using Microsoft.AspNetCore.Mvc;

namespace DegreeProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IService<ProjectDTO> _projectService;
        public ProjectController(IService<ProjectDTO> projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProjectDTO>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var project = await _projectService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(project);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ProjectDTO))]
        public async Task<IActionResult> Get(int id)
        {
            if (!await _projectService.Exist(id))
                return NotFound();

            var work = await _projectService.Get(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(work);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProjectDTO project)
        {
            if (project == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _projectService.Create(project);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProjectDTO projectPut)
        {
            if (projectPut == null)
                return BadRequest(ModelState);

            if (!await _projectService.Exist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var project = await _projectService.Update(id, projectPut);
            return Ok(project);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _projectService.Exist(id))
                return NotFound();

            var result = await _projectService.Delete(id);

            return Ok(result);
        }
    }
}
