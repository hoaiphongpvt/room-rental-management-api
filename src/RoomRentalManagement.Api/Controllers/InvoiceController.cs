using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomRentalManagement.Application.Common.Models;
using RoomRentalManagement.Application.Invoices;
using RoomRentalManagement.Application.Invoices.Dtos;

namespace RoomRentalManagement.Api.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    [Authorize]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: api/invoices
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<InvoiceDto>>>> GetInvoices()
        {
            var invoices = await _invoiceService.GetInvoicesAsync();

            return Ok(ApiResponse<List<InvoiceDto>>.SuccessResponse(invoices));
        }

        // GET: api/invoices/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<InvoiceDto>>> GetInvoice(Guid id)
        {
            var invoice = await _invoiceService.GetInvoiceAsync(id);

            if (invoice == null)
            {
                return NotFound(ApiResponse<InvoiceDto>.Fail("Invoice not found"));
            }

            return Ok(ApiResponse<InvoiceDto>.SuccessResponse(invoice));
        }

        // POST: api/invoices
        [HttpPost]
        public async Task<ActionResult<ApiResponse<InvoiceDto>>> CreateInvoice(CreateInvoiceRequest request)
        {
            var created = await _invoiceService.CreateInvoiceAsync(request);

            return CreatedAtAction(nameof(GetInvoice), new { id = created.Id }, ApiResponse<InvoiceDto>.SuccessResponse(created, "Invoice created"));
        }

        // PUT: api/invoices/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> UpdateInvoice(Guid id, UpdateInvoiceRequest request)
        {
            var updated = await _invoiceService.UpdateInvoiceAsync(id, request);

            if (!updated)
            {
                return NotFound(ApiResponse<object>.Fail("Invoice not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Invoice updated"));
        }

        // DELETE: api/invoices/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteInvoice(Guid id)
        {
            var deleted = await _invoiceService.DeleteInvoiceAsync(id);

            if (!deleted)
            {
                return NotFound(ApiResponse<object>.Fail("Invoice not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Invoice deleted"));
        }
    }
}
