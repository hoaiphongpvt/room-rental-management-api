namespace RoomRentalManagement.Application.Contracts.Dtos
{
    public class UpdateContractRequest
    {
        public Guid RoomId { get; set; }

        public Guid CustomerId { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public decimal Deposit { get; set; }

        public decimal MonthlyRent { get; set; }

        public string Status { get; set; } = null!;
    }
}
