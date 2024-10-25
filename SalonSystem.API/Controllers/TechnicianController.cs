using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.Technicians;
using SalonSystem.Services;
using SalonSystem.DTOs;
using AutoMapper;

namespace SalonSystem.API.Controllers  
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianController : ControllerBase 
    {
        private readonly TechnicianService _technicianService;
        private readonly IMapper _mapper;

        public TechnicianController(TechnicianService technicianService, IMapper mapper)
        {
            _technicianService = technicianService;
            _mapper = mapper;
        }

        // GET: api/technician
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechnicianDto>>> GetAllTechnicians()
        {
            var technicians = await _technicianService.GetAllTechniciansAsync();
            var technicianDtos = _mapper.Map<IEnumerable<TechnicianDto>>(technicians);
            return Ok(technicianDtos);
        }

        // GET: api/technician/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TechnicianDto>> GetTechnicianById(int id) 
        {
            var technician = await _technicianService.GetTechnicianByIdAsync(id);
            if (technician == null)
            {
                return NotFound();
            } 
            var technicianDto = _mapper.Map<TechnicianDto>(technician);
            return Ok(technicianDto);
        }

        // POST: api/technician
        [HttpPost]
        public async Task<ActionResult<TechnicianDto>> AddTechnician(CreateTechnicianDto technicianDto)
        {
            var newTechnician = await _technicianService.AddTechnicianAsync(technicianDto);
            var technicianDtoResponse = _mapper.Map<TechnicianDto>(newTechnician);
            return CreatedAtAction(nameof(GetTechnicianById), new { id = technicianDtoResponse.TechnicianId }, technicianDtoResponse);
        }

        // PUT: api/technician/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTechnician(int id, UpdateTechnicianDto updateTechnicianDto) 
        {
            if (id != updateTechnicianDto.TechnicianId) 
            {
                return BadRequest("Technician ID in the route does not match ID in the payload.");
            }

            // Map DTO to Technician model
            var technician = _mapper.Map<Technician>(updateTechnicianDto);
            
            // Update technician in the service
            var updatedTechnician = await _technicianService.UpdateTechnicianAsync(id, technician);

            if (updatedTechnician == null) 
            {
                return NotFound();
            }

            // Return the updated technician details
            return Ok(_mapper.Map<TechnicianDto>(updatedTechnician));
        }

        // DELETE: api/technician/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnician(int id)
        {
            var result = await _technicianService.DeleteTechnicianAsync(id);
            if (!result) 
            {
                return NotFound();
            }
            return NoContent();
        }
    } 
}
