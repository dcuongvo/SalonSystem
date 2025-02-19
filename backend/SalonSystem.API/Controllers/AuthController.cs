    using Microsoft.AspNetCore.Mvc;
using SalonSystem.Application.Services.Users.Interfaces;
using SalonSystem.Application.Services.Authentication.Interfaces;
using SalonSystem.Domain.Entities.Users;
using SalonSystem.API.DTOs.User;

namespace SalonSystem.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IUserService userService, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }

 [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
    {
        // Map DTO to User entity
        var user = new User
        {
            Username = userDto.Username,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email
        };

        try
        {
            var result = await _userService.RegisterUserAsync(user, userDto.Password);
            if (result) return Ok("User registered successfully.");
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message); // Handle conflicts like duplicate username/email
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message); // Handle validation errors
        }

        return StatusCode(500, "An error occurred while registering the user.");
    }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var token = await _authenticationService.LoginUserAsync(loginDto.Username, loginDto.Password);
            return token != null ? Ok(new { Token = token }) : Unauthorized("Invalid username or password.");
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await _userService.DeleteUserAsync(userId);
            return result ? Ok("User deleted successfully.") : NotFound("User not found.");
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var result = await _userService.ChangePasswordAsync(
                userId: changePasswordDto.UserId,
                currentPassword: changePasswordDto.CurrentPassword,
                newPassword: changePasswordDto.NewPassword
            );

            return result ? Ok("Password changed successfully.") : BadRequest("Failed to change password.");
        }
    }
}
