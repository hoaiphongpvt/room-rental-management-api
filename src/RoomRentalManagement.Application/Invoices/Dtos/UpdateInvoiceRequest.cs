namespace RoomRentalManagement.Application.Invoices.Dtos
{
    public class UpdateInvoiceRequest
    {
        public Guid ContractId { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = null!;

        public DateOnly DueDate { get; set; }
    }
}
