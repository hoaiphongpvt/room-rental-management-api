using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomRentalManagement.Application.Common.Models;
using RoomRentalManagement.Application.ServiceDetails;
using RoomRentalManagement.Application.ServiceDetails.Dtos;

namespace RoomRentalManagement.Api.Controllers
{
    [ApiController]
    [Route("api/service-details")]
    [Authorize]
    public class ServiceDetailController : ControllerBase
    {
        private readonly IServiceDetailService _serviceDetailService;

        public ServiceDetailController(IServiceDetailService serviceDetailService)
        {
            _serviceDetailService = serviceDetailService;
        }

        // GET: api/service-details
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ServiceDetailDto>>>> GetServiceDetails()
        {
            var serviceDetails = await _serviceDetailService.GetServiceDetailsAsync();

            return Ok(ApiResponse<List<ServiceDetailDto>>.SuccessResponse(serviceDetails));
        }

        // GET: api/service-details/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ServiceDetailDto>>> GetServiceDetail(Guid id)
        {
            var serviceDetail = await _serviceDetailService.GetServiceDetailAsync(id);

            if (serviceDetail == null)
            {
                return NotFound(ApiResponse<ServiceDetailDto>.Fail("Service detail not found"));
            }

            return Ok(ApiResponse<ServiceDetailDto>.SuccessResponse(serviceDetail));
        }

        // POST: api/service-details
        [HttpPost]
        public async Task<ActionResult<ApiResponse<ServiceDetailDto>>> CreateServiceDetail(CreateServiceDetailRequest request)
        {
            var created = await _serviceDetailService.CreateServiceDetailAsync(request);

            return CreatedAtAction(nameof(GetServiceDetail), new { id = created.Id }, ApiResponse<ServiceDetailDto>.SuccessResponse(created, "Service detail created"));
        }

        // PUT: api/service-details/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> UpdateServiceDetail(Guid id, UpdateServiceDetailRequest request)
        {
            var updated = await _serviceDetailService.UpdateServiceDetailAsync(id, request);

            if (!updated)
            {
                return NotFound(ApiResponse<object>.Fail("Service detail not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Service detail updated"));
        }

        // DELETE: api/service-details/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteServiceDetail(Guid id)
        {
            var deleted = await _serviceDetailService.DeleteServiceDetailAsync(id);

            if (!deleted)
            {
                return NotFound(ApiResponse<object>.Fail("Service detail not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Service detail deleted"));
        }
    }
}
