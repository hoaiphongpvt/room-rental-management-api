using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomRentalManagement.Application.Common.Models;
using RoomRentalManagement.Application.Pictures;
using RoomRentalManagement.Application.Pictures.Dtos;

namespace RoomRentalManagement.Api.Controllers
{
    [ApiController]
    [Route("api/pictures")]
    [Authorize]
    public class PictureController : ControllerBase
    {
        private readonly IPictureService _pictureService;

        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        // GET: api/pictures
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<PictureDto>>>> GetPictures()
        {
            var pictures = await _pictureService.GetPicturesAsync();

            return Ok(ApiResponse<List<PictureDto>>.SuccessResponse(pictures));
        }

        // GET: api/pictures/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PictureDto>>> GetPicture(Guid id)
        {
            var picture = await _pictureService.GetPictureAsync(id);

            if (picture == null)
            {
                return NotFound(ApiResponse<PictureDto>.Fail("Picture not found"));
            }

            return Ok(ApiResponse<PictureDto>.SuccessResponse(picture));
        }

        // POST: api/pictures
        [HttpPost]
        public async Task<ActionResult<ApiResponse<PictureDto>>> CreatePicture(CreatePictureRequest request)
        {
            var created = await _pictureService.CreatePictureAsync(request);

            return CreatedAtAction(nameof(GetPicture), new { id = created.Id }, ApiResponse<PictureDto>.SuccessResponse(created, "Picture created"));
        }

        // PUT: api/pictures/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> UpdatePicture(Guid id, UpdatePictureRequest request)
        {
            var updated = await _pictureService.UpdatePictureAsync(id, request);

            if (!updated)
            {
                return NotFound(ApiResponse<object>.Fail("Picture not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Picture updated"));
        }

        // DELETE: api/pictures/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeletePicture(Guid id)
        {
            var deleted = await _pictureService.DeletePictureAsync(id);

            if (!deleted)
            {
                return NotFound(ApiResponse<object>.Fail("Picture not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Picture deleted"));
        }
    }
}
