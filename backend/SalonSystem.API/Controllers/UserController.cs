using Microsoft.AspNetCore.Mvc;
using SalonSystem.Application.Services.Users.Interfaces;
using SalonSystem.Domain.Entities.Users;
using SalonSystem.API.DTOs.User;
using SalonSystem.API.DTOs.Salon;
using System.Threading.Tasks;

namespace SalonSystem.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("salons")]
        public async Task<IActionResult> GetUserSalons()
        {
            var userIdClaim = User.FindFirst("id");
            if (userIdClaim == null) return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

            var salons = await _userService.GetUserSalonsAsync(userId);
            if (salons == null)
            {
                return NotFound("No salons found for this user.");
            }
                // Map to SalonInfoDto
            var salonDtos = salons.Select(salon => new SalonInfoDto
            {
                SalonId = salon.SalonId,
                Name = salon.Name,
                Address = salon.Address,
                City = salon.City,
                State = salon.State,
                ZipCode = salon.ZipCode
            }).ToList();

            return Ok(salonDtos);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GetUserWithDetailsByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }


        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await _userService.DeleteUserAsync(userId);
            return result ? Ok("User deleted successfully.") : NotFound("User not found.");
        }
    }
}
