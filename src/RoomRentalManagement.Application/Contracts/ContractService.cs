using RoomRentalManagement.Application.Common.Interfaces;
using RoomRentalManagement.Application.Contracts.Dtos;
using RoomRentalManagement.Domain.Entities;

namespace RoomRentalManagement.Application.Contracts
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContractService(IContractRepository contractRepository, IUnitOfWork unitOfWork)
        {
            _contractRepository = contractRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ContractDto>> GetContractsAsync()
        {
            var contracts = await _contractRepository.GetAllAsync();

            return contracts.Select(ToDto).ToList();
        }

        public async Task<ContractDto?> GetContractAsync(Guid id)
        {
            var contract = await _contractRepository.GetByIdAsync(id);

            return contract == null ? null : ToDto(contract);
        }

        public async Task<ContractDto> CreateContractAsync(CreateContractRequest request)
        {
            var contract = new Contract
            {
                Id = Guid.NewGuid(),
                RoomId = request.RoomId,
                CustomerId = request.CustomerId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Deposit = request.Deposit,
                MonthlyRent = request.MonthlyRent,
                Status = request.Status
            };

            await _contractRepository.AddAsync(contract);
            await _unitOfWork.SaveChangesAsync();

            return ToDto(contract);
        }

        public async Task<bool> UpdateContractAsync(Guid id, UpdateContractRequest request)
        {
            var contract = await _contractRepository.GetByIdAsync(id);

            if (contract == null)
            {
                return false;
            }

            contract.RoomId = request.RoomId;
            contract.CustomerId = request.CustomerId;
            contract.StartDate = request.StartDate;
            contract.EndDate = request.EndDate;
            contract.Deposit = request.Deposit;
            contract.MonthlyRent = request.MonthlyRent;
            contract.Status = request.Status;

            _contractRepository.Update(contract);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteContractAsync(Guid id)
        {
            var contract = await _contractRepository.GetByIdAsync(id);

            if (contract == null)
            {
                return false;
            }

            _contractRepository.Remove(contract);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        private static ContractDto ToDto(Contract contract) => new()
        {
            Id = contract.Id,
            RoomId = contract.RoomId,
            CustomerId = contract.CustomerId,
            StartDate = contract.StartDate,
            EndDate = contract.EndDate,
            Deposit = contract.Deposit,
            MonthlyRent = contract.MonthlyRent,
            Status = contract.Status,
            CreatedAt = contract.CreatedAt,
            UpdatedAt = contract.UpdatedAt
        };
    }
}
