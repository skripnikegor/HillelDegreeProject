using DegreeProject.BL.Interfaces.Generic;
using DegreeProject.BL.Models;
using DegreeProject.DTO.Projects;
using Microsoft.AspNetCore.Mvc;

namespace DegreeProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateController : Controller
    {
        private readonly IService<EstimateDTO> _estimateService;
        public EstimateController(IService<EstimateDTO> estimateService)
        {
            _estimateService = estimateService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EstimateDTO>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var works = await _estimateService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(works);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(EstimateDTO))]
        public async Task<IActionResult> Get(int id)
        {
            if (!await _estimateService.Exist(id))
                return NotFound();

            var work = await _estimateService.Get(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(work);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EstimateDTO estimateCreate)
        {
            if (estimateCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var estimate = await _estimateService.Create(estimateCreate);
            return Ok(estimate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EstimateDTO estimatePut)
        {
            if (estimatePut == null)
                return BadRequest(ModelState);

            if (!await _estimateService.Exist(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var standart = await _estimateService.Update(id, estimatePut);
            return Ok(standart);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _estimateService.Exist(id))
                return NotFound();

            var result = await _estimateService.Delete(id);

            return Ok(result);
        }

        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<EstimateDTO>))]
        //public async Task<IActionResult> GetCalculatedEstiamte(int Id)
        //{
        //    var works = await _estimateService.GetAll();
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    return Ok(works);
        //}
    }
}
