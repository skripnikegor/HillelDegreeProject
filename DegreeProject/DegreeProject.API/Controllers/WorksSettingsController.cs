using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.BL.Models;
using DegreeProject.DTO.Projects;
using Microsoft.AspNetCore.Mvc;

namespace DegreeProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksSettingsController : Controller
    {
        private readonly IService<WorksSettingsDTO> _worksSettingsService;

        public WorksSettingsController(IService<WorksSettingsDTO> worksSettingService)
        {
            _worksSettingsService = worksSettingService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<WorksSettingsDTO>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var worksSettings = await _worksSettingsService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(worksSettings);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(WorksSettingsDTO))]
        public async Task<IActionResult> Get(int id)
        {
            if (!await _worksSettingsService.Exist(id))
                return NotFound();

            var worksSetting = await _worksSettingsService.Get(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(worksSetting);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WorksSettingsDTO worksSettingsCreate)
        {
            if (worksSettingsCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var worksSetting = await _worksSettingsService.Create(worksSettingsCreate);
            return Ok(worksSetting);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] WorksSettingsDTO worksSettingsPut)
        {
            if (worksSettingsPut == null)
                return BadRequest(ModelState);

            if (!await _worksSettingsService.Exist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var workSetting = await _worksSettingsService.Update(id, worksSettingsPut);
            return Ok(workSetting);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _worksSettingsService.Exist(id))
                return NotFound();

            var result = await _worksSettingsService.Delete(id);

            return Ok(result);
        }
    }
}
