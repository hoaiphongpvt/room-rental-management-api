using Microsoft.AspNetCore.Mvc;
using RoomRentalManagement.Application.Common.Models;
using RoomRentalManagement.Application.Users;
using RoomRentalManagement.Domain.Entities;

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
        public async Task<ActionResult<ApiResponse<List<User>>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();

            return Ok(ApiResponse<List<User>>.SuccessResponse(users));
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<User>>> GetUser(Guid id)
        {
            var user = await _userService.GetUserAsync(id);

            if (user == null)
            {
                return NotFound(ApiResponse<User>.Fail("User not found"));
            }

            return Ok(ApiResponse<User>.SuccessResponse(user));
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<ApiResponse<User>>> CreateUser(User user)
        {
            var created = await _userService.CreateUserAsync(user);

            return CreatedAtAction(nameof(GetUser), new { id = created.Id }, ApiResponse<User>.SuccessResponse(created, "User created"));
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> UpdateUser(Guid id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest(ApiResponse<object>.Fail("Route id does not match body id"));
            }

            var updated = await _userService.UpdateUserAsync(id, user);

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
