using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomRentalManagement.Application.Common.Models;
using RoomRentalManagement.Application.Contracts;
using RoomRentalManagement.Application.Contracts.Dtos;

namespace RoomRentalManagement.Api.Controllers
{
    [ApiController]
    [Route("api/contracts")]
    [Authorize]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        // GET: api/contracts
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ContractDto>>>> GetContracts()
        {
            var contracts = await _contractService.GetContractsAsync();

            return Ok(ApiResponse<List<ContractDto>>.SuccessResponse(contracts));
        }

        // GET: api/contracts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ContractDto>>> GetContract(Guid id)
        {
            var contract = await _contractService.GetContractAsync(id);

            if (contract == null)
            {
                return NotFound(ApiResponse<ContractDto>.Fail("Contract not found"));
            }

            return Ok(ApiResponse<ContractDto>.SuccessResponse(contract));
        }

        // POST: api/contracts
        [HttpPost]
        public async Task<ActionResult<ApiResponse<ContractDto>>> CreateContract(CreateContractRequest request)
        {
            var created = await _contractService.CreateContractAsync(request);

            return CreatedAtAction(nameof(GetContract), new { id = created.Id }, ApiResponse<ContractDto>.SuccessResponse(created, "Contract created"));
        }

        // PUT: api/contracts/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> UpdateContract(Guid id, UpdateContractRequest request)
        {
            var updated = await _contractService.UpdateContractAsync(id, request);

            if (!updated)
            {
                return NotFound(ApiResponse<object>.Fail("Contract not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Contract updated"));
        }

        // DELETE: api/contracts/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteContract(Guid id)
        {
            var deleted = await _contractService.DeleteContractAsync(id);

            if (!deleted)
            {
                return NotFound(ApiResponse<object>.Fail("Contract not found"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Contract deleted"));
        }
    }
}
