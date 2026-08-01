namespace RoomRentalManagement.Application.InvoiceDetails.Dtos
{
    public class InvoiceDetailDto
    {
        public Guid Id { get; set; }

        public Guid InvoiceId { get; set; }

        public Guid ServiceId { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }
    }
}
