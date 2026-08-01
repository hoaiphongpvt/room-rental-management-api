using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomRentalManagement.Application.Common.Models;
using RoomRentalManagement.Application.Services;
using RoomRentalManagement.Application.Services.Dtos;

namespace RoomRentalManagement.Api.Controllers
{
    [ApiController]
    [Route("api/services")]
    [Authorize]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET: api/services
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ServiceDto>>>> GetServices()
        {
            var services = await _serviceService.GetServicesAsync();

            return Ok(ApiResponse<List<ServiceDto>>.SuccessResponse(services));
        }

        // GET: api/services/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ServiceDto>>> GetService(Guid id)
        {
            var service = await _serviceService.GetServiceAsync(id);

            if (service == null)
            {
                return NotFound(ApiResponse<ServiceDto>.Fail("Service not found"));
            }

            return Ok(ApiResponse<ServiceDto>.SuccessResponse(service));
        }

        // POST: api/services
        [HttpPost]
        public async Task<ActionResult<ApiResponse<ServiceDto>>> CreateService(CreateServiceRequest request)
        {
            var created = await _serviceService.CreateServiceAsync(request);

            return CreatedAtAction(nameof(GetService), new { id = created.Id }, ApiResponse<ServiceDto>.SuccessResponse(created, "Service created"));
        }

        // PUT: api/services/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> UpdateService(Guid id, UpdateServiceRequest request)
        {
            var updated = await _serviceService.UpdateServiceAsync(id, request);

            if (!updated)
            {
                return NotFound(ApiResponse<object>.Fail("Service not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Service updated"));
        }

        // DELETE: api/services/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteService(Guid id)
        {
            var deleted = await _serviceService.DeleteServiceAsync(id);

            if (!deleted)
            {
                return NotFound(ApiResponse<object>.Fail("Service not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Service deleted"));
        }
    }
}
