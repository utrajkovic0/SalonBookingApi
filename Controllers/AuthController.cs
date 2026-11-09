using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonBookingApi.DTOs;
using SalonBookingApi.Services;

namespace SalonBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto request)
        {
            var result = await _authService.RegisterAsync(request);
            if (!result) return BadRequest("Korisnicko ime je zauzeto");

            return Ok("Registracija uspesna");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var token = await _authService.LoginAsync(request);
            if (token == null) return Unauthorized("Pogresno korisnicko ime ili lozinka");

            return Ok(new { token });
        }
    }
}
