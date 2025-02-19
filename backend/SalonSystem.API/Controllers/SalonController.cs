using Microsoft.AspNetCore.Mvc;
using SalonSystem.Application.Services.Salons.Interfaces;
using SalonSystem.Domain.Entities.Salons;
using SalonSystem.API.DTOs.Salon;
using System.Threading.Tasks;

namespace SalonSystem.API.Controllers
{
    [ApiController]
    [Route("api/salon")]
    public class SalonController : ControllerBase
    {
        private readonly ISalonService _salonService;

        public SalonController(ISalonService salonService)
        {
            _salonService = salonService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSalon([FromBody] AddSalonDto salonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid salon data.");
            }

            var userIdClaim = User.FindFirst("id");
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            int userId = int.Parse(userIdClaim.Value);

            try
            {
                var newSalon = new Salon
                {
                    Name = salonDto.Name,
                    Address = salonDto.Address,
                    City = salonDto.City,
                    State = salonDto.State,
                    ZipCode = salonDto.ZipCode,
                    OwnerId = userId
                };

                var createdSalon = await _salonService.AddSalonAsync(newSalon);
                return Ok(createdSalon); // Return the newly created salon with its details
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the salon: {ex.Message}");
            }
        }
    }
}
