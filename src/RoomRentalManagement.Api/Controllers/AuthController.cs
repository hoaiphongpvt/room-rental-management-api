using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomRentalManagement.Application.Auth;
using RoomRentalManagement.Application.Auth.Dtos;
using RoomRentalManagement.Application.Common.Models;
using RoomRentalManagement.Application.Users.Dtos;

namespace RoomRentalManagement.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<LoginResponse>>> Login(LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);

            if (result == null)
            {
                return Unauthorized(ApiResponse<LoginResponse>.Fail("Invalid email or password"));
            }

            return Ok(ApiResponse<LoginResponse>.SuccessResponse(result, "Login successful"));
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<UserDto>>> Register(RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);

            if (result == null)
            {
                return Conflict(ApiResponse<UserDto>.Fail("Email already registered"));
            }

            return StatusCode(StatusCodes.Status201Created, ApiResponse<UserDto>.SuccessResponse(result, "Registration successful"));
        }
    }
}
