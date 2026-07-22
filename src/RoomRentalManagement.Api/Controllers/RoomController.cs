using Microsoft.AspNetCore.Mvc;
using RoomRentalManagement.Application.Common.Models;
using RoomRentalManagement.Application.Rooms;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Api.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/rooms
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Room>>>> GetRooms()
        {
            var rooms = await _roomService.GetRoomsAsync();

            return Ok(ApiResponse<List<Room>>.SuccessResponse(rooms));
        }

        // GET: api/rooms/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Room>>> GetRoom(Guid id)
        {
            var room = await _roomService.GetRoomAsync(id);

            if (room == null)
            {
                return NotFound(ApiResponse<Room>.Fail("Room not found"));
            }

            return Ok(ApiResponse<Room>.SuccessResponse(room));
        }

        // POST: api/rooms
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Room>>> CreateRoom(Room room)
        {
            var created = await _roomService.CreateRoomAsync(room);

            return CreatedAtAction(nameof(GetRoom), new { id = created.Id }, ApiResponse<Room>.SuccessResponse(created, "Room created"));
        }

        // PUT: api/rooms/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> UpdateRoom(Guid id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest(ApiResponse<object>.Fail("Route id does not match body id"));
            }

            var updated = await _roomService.UpdateRoomAsync(id, room);

            if (!updated)
            {
                return NotFound(ApiResponse<object>.Fail("Room not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Room updated"));
        }

        // DELETE: api/rooms/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteRoom(Guid id)
        {
            var deleted = await _roomService.DeleteRoomAsync(id);

            if (!deleted)
            {
                return NotFound(ApiResponse<object>.Fail("Room not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Room deleted"));
        }
    }
}
