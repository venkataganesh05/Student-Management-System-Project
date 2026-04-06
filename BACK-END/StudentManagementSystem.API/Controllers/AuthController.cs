using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Core.DTOs;
using StudentManagementSystem.Core.Interfaces.Services;

namespace StudentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;   // ✅ ADD THIS

        public AuthController(IAuthService authService)  // ✅ CONSTRUCTOR
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var token = await _authService.Login(dto);

            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
    }
}