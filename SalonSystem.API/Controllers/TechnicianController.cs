using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.Technicians;
using SalonSystem.Services;

namespace SalonSystem.API.Controllers  
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianController : ControllerBase 
    {
        private readonly TechnicianService _technicianService;

        public TechnicianController(TechnicianService technicianService)
        {
            _technicianService = technicianService;
        }

        //GET http request to get all techncians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Technician>>> GetAllTechnician()
        {
            var technicians = await _technicianService.GetAllTechniciansAsync();
            return Ok(technicians);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Technician>> GetTechnicianById(int id) 
        {
            var technician = await _technicianService.GetTechnicianByIdAsync(id);
            if (technician == null)
            {
                return NotFound();
            } 
            return Ok(technician);
        }

        [HttpPost]
        public async Task<ActionResult<Technician>> AddTechnician(Technician technician)
        {
            var newTechnician = await _technicianService.AddTechnicianAsync(technician);                                       
            return CreatedAtAction(nameof(GetTechnicianById), new {id = newTechnician.TechnicianId}, newTechnician);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTechnician(int id, Technician technician) 
        {
            if (id != technician.TechnicianId) 
            {
                return BadRequest();
            }

            var updatedTechnician = await _technicianService.UpdateTechnicianAsync(id,technician);
            if (updatedTechnician == null) 
            {
                return NotFound();
            }
            return NoContent();
            //return Ok(updatedTechnician)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnician(int id)
        {
            var result = await _technicianService.DeleteTechnicianAsync(id);
            if (!result) 
            {
                return NotFound();
            }
            return NoContent();
            //return Ok()?
        }

    } 
}