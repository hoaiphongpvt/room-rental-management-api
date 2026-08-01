using RoomRentalManagement.Application.Contracts.Dtos;

namespace RoomRentalManagement.Application.Contracts
{
    public interface IContractService
    {
        Task<List<ContractDto>> GetContractsAsync();
        Task<ContractDto?> GetContractAsync(Guid id);
        Task<ContractDto> CreateContractAsync(CreateContractRequest request);
        Task<bool> UpdateContractAsync(Guid id, UpdateContractRequest request);
        Task<bool> DeleteContractAsync(Guid id);
    }
}
