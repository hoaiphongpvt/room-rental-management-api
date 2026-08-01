using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomRentalManagement.Application.Common.Models;
using RoomRentalManagement.Application.InvoiceDetails;
using RoomRentalManagement.Application.InvoiceDetails.Dtos;

namespace RoomRentalManagement.Api.Controllers
{
    [ApiController]
    [Route("api/invoice-details")]
    [Authorize]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly IInvoiceDetailService _invoiceDetailService;

        public InvoiceDetailController(IInvoiceDetailService invoiceDetailService)
        {
            _invoiceDetailService = invoiceDetailService;
        }

        // GET: api/invoice-details
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<InvoiceDetailDto>>>> GetInvoiceDetails()
        {
            var invoiceDetails = await _invoiceDetailService.GetInvoiceDetailsAsync();

            return Ok(ApiResponse<List<InvoiceDetailDto>>.SuccessResponse(invoiceDetails));
        }

        // GET: api/invoice-details/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<InvoiceDetailDto>>> GetInvoiceDetail(Guid id)
        {
            var invoiceDetail = await _invoiceDetailService.GetInvoiceDetailAsync(id);

            if (invoiceDetail == null)
            {
                return NotFound(ApiResponse<InvoiceDetailDto>.Fail("Invoice detail not found"));
            }

            return Ok(ApiResponse<InvoiceDetailDto>.SuccessResponse(invoiceDetail));
        }

        // POST: api/invoice-details
        [HttpPost]
        public async Task<ActionResult<ApiResponse<InvoiceDetailDto>>> CreateInvoiceDetail(CreateInvoiceDetailRequest request)
        {
            var created = await _invoiceDetailService.CreateInvoiceDetailAsync(request);

            return CreatedAtAction(nameof(GetInvoiceDetail), new { id = created.Id }, ApiResponse<InvoiceDetailDto>.SuccessResponse(created, "Invoice detail created"));
        }

        // PUT: api/invoice-details/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> UpdateInvoiceDetail(Guid id, UpdateInvoiceDetailRequest request)
        {
            var updated = await _invoiceDetailService.UpdateInvoiceDetailAsync(id, request);

            if (!updated)
            {
                return NotFound(ApiResponse<object>.Fail("Invoice detail not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Invoice detail updated"));
        }

        // DELETE: api/invoice-details/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteInvoiceDetail(Guid id)
        {
            var deleted = await _invoiceDetailService.DeleteInvoiceDetailAsync(id);

            if (!deleted)
            {
                return NotFound(ApiResponse<object>.Fail("Invoice detail not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Invoice detail deleted"));
        }
    }
}
