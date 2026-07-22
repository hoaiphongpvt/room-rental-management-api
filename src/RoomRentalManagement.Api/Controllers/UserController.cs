using Microsoft.AspNetCore.Mvc;
using RoomRentalManagement.Application.Common.Models;
using RoomRentalManagement.Application.Users;
using RoomRentalManagement.Application.Users.Dtos;

namespace RoomRentalManagement.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<UserDto>>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();

            return Ok(ApiResponse<List<UserDto>>.SuccessResponse(users));
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<UserDto>>> GetUser(Guid id)
        {
            var user = await _userService.GetUserAsync(id);

            if (user == null)
            {
                return NotFound(ApiResponse<UserDto>.Fail("User not found"));
            }

            return Ok(ApiResponse<UserDto>.SuccessResponse(user));
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<ApiResponse<UserDto>>> CreateUser(CreateUserRequest request)
        {
            var created = await _userService.CreateUserAsync(request);

            return CreatedAtAction(nameof(GetUser), new { id = created.Id }, ApiResponse<UserDto>.SuccessResponse(created, "User created"));
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> UpdateUser(Guid id, UpdateUserRequest request)
        {
            var updated = await _userService.UpdateUserAsync(id, request);

            if (!updated)
            {
                return NotFound(ApiResponse<object>.Fail("User not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "User updated"));
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteUser(Guid id)
        {
            var deleted = await _userService.DeleteUserAsync(id);

            if (!deleted)
            {
                return NotFound(ApiResponse<object>.Fail("User not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "User deleted"));
        }
    }
}
