namespace CarSharing.Domain.Dto.CarUsage.Response
{
    using System;

    public class CarUsageDto
    {
        public int CarUsageId { get; set; }
        public Guid ClientId { get; set; }
        public int WalletId { get; set; }
        public Guid CarId { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime EndDateUtc { get; set; }
        public decimal TotalAmount { get; set; }
        public int StatusId { get; set; }
    }
}
