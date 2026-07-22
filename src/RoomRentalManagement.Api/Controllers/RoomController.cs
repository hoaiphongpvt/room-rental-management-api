using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await _roomService.GetRoomsAsync();
        }

        // GET: api/rooms/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(Guid id)
        {
            var room = await _roomService.GetRoomAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // POST: api/rooms
        [HttpPost]
        public async Task<ActionResult<Room>> CreateRoom(Room room)
        {
            var created = await _roomService.CreateRoomAsync(room);

            return CreatedAtAction(nameof(GetRoom), new { id = created.Id }, created);
        }

        // PUT: api/rooms/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(Guid id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            var updated = await _roomService.UpdateRoomAsync(id, room);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/rooms/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(Guid id)
        {
            var deleted = await _roomService.DeleteRoomAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
