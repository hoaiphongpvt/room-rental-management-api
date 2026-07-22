using Microsoft.AspNetCore.Mvc;
using RoomRentalManagement.Application.Common.Models;
using RoomRentalManagement.Application.Rooms;
using RoomRentalManagement.Application.Rooms.Dtos;

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
        public async Task<ActionResult<ApiResponse<List<RoomDto>>>> GetRooms()
        {
            var rooms = await _roomService.GetRoomsAsync();

            return Ok(ApiResponse<List<RoomDto>>.SuccessResponse(rooms));
        }

        // GET: api/rooms/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<RoomDto>>> GetRoom(Guid id)
        {
            var room = await _roomService.GetRoomAsync(id);

            if (room == null)
            {
                return NotFound(ApiResponse<RoomDto>.Fail("Room not found"));
            }

            return Ok(ApiResponse<RoomDto>.SuccessResponse(room));
        }

        // POST: api/rooms
        [HttpPost]
        public async Task<ActionResult<ApiResponse<RoomDto>>> CreateRoom(CreateRoomRequest request)
        {
            var created = await _roomService.CreateRoomAsync(request);

            return CreatedAtAction(nameof(GetRoom), new { id = created.Id }, ApiResponse<RoomDto>.SuccessResponse(created, "Room created"));
        }

        // PUT: api/rooms/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> UpdateRoom(Guid id, UpdateRoomRequest request)
        {
            var updated = await _roomService.UpdateRoomAsync(id, request);

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
