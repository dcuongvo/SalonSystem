using Microsoft.AspNetCore.Mvc;
using SalonSystem.Models.Salons;
using SalonSystem.Services;

namespace SalonSystem.API.Controllers  
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonController : ControllerBase 
    {
        private readonly SalonService _salonService;

        public SalonController(SalonService salonService)
        {
            _salonService = salonService;
        }

        //GET http request to get all techncians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salon>>> GetAllSalon()
        {
            var salons = await _salonService.GetAllSalonsAsync();
            return Ok(salons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Salon>> GetSalonById(int id) 
        {
            var salon = await _salonService.GetSalonByIdAsync(id);
            if (salon == null)
            {
                return NotFound();
            } 
            return Ok(salon);
        }

        [HttpPost]
        public async Task<ActionResult<Salon>> AddSalon(Salon salon)
        {
            var newSalon = await _salonService.AddSalonAsync(salon);                                       
            return CreatedAtAction(nameof(GetSalonById), new {id = newSalon.SalonId}, newSalon);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalon(int id, Salon salon) 
        {
            if (id != salon.SalonId) 
            {
                return BadRequest();
            }

            var updatedSalon = await _salonService.UpdateSalonAsync(id,salon);
            if (updatedSalon == null) 
            {
                return NotFound();
            }
            return NoContent();
            //return Ok(updatedSalon)
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