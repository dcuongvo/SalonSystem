using Microsoft.AspNetCore.Mvc;
using SalonSystem.Data.Repositories;
using SalonSystem.Models.Technicians;

namespace SalonSystem.API.Controllers  
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianController : ControllerBase 
    {
        private readonly ITechnicianRepository _technicianRepository;

        public TechnicianController(ITechnicianRepository technicianRepository)
        {
            _technicianRepository = technicianRepository;
        }

        //GET http request to get all techncians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Technician>>> GetAllTechnician()
        {
            var technicians = await _technicianRepository.GetAllTechniciansAsync();
            return Ok(technicians);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Technician>> GetTechnicianById(int id) 
        {
            var technician = await _technicianRepository.GetTechnicianByIdAsync(id);
            if (technician == null)
            {
                return NotFound();
            } 
            return Ok(technician);
        }

        [HttpPost]
        public async Task<ActionResult<Technician>> AddTechnician(Technician technician)
        {
            var newTechnician = await _technicianRepository.AddTechnicianAsync(technician);                                       
            return CreatedAtAction(nameof(GetTechnicianById), new {id = newTechnician.TechnicianId}, newTechnician);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTechnician(int id, Technician technician) 
        {
            if (id != technician.TechnicianId) 
            {
                return BadRequest();
            }

            var updatedTechnician = await _technicianRepository.UpdateTechnicianAsync(technician);
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
            var result = await _technicianRepository.DeleteTechnicianAsync(id);
            if (!result) 
            {
                return NotFound();
            }
            return NoContent();
            //Ok()
        }

    } 
}