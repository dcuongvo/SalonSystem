using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.Salons;
using SalonSystem.Services;
using SalonSystem.DTOs;
using AutoMapper;

namespace SalonSystem.API.Controllers  
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonController : ControllerBase 
    {
        private readonly SalonService _salonService;
        private readonly IMapper _mapper;

        public SalonController(SalonService salonService, IMapper mapper)
        {
            _salonService = salonService;
            _mapper = mapper;
        }

        //GET http request to get all techncians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salon>>> GetAllSalon()
        {
            var salons = await _salonService.GetAllSalonsAsync();
            return Ok(salons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalonDto>> GetSalonById(int id)
        {
            var salon = await _salonService.GetSalonByIdAsync(id);
            if (salon == null)
            {
                return NotFound();
            }

            // Map the salon entity to the DTO in the controller
            var salonDto = _mapper.Map<SalonDto>(salon);
            return Ok(salonDto);
        }


        [HttpPost]
        public async Task<ActionResult<SalonDto>> AddSalon(CreateSalonDto salonDto)
        {
            var salon = _mapper.Map<Salon>(salonDto);
            var newSalon = await _salonService.AddSalonAsync(salon);
            var newSalonDto = _mapper.Map<SalonDto>(newSalon);
            return CreatedAtAction(nameof(GetSalonById), new { id = newSalonDto.SalonId }, newSalonDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalon(int id, UpdateSalonDto salonDto)
        {
            if (id != salonDto.SalonId)
            {
                return BadRequest();
            }

            var salon = _mapper.Map<Salon>(salonDto);
            var updatedSalon = await _salonService.UpdateSalonAsync(id, salon);
            if (updatedSalon == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalon(int id)
        {
            var result = await _salonService.DeleteSalonAsync(id);
            if (!result) 
            {
                return NotFound();
            }
            return NoContent();
            //return Ok()?
        }

    } 
}