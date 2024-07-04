namespace CarSharing.Domain.Dto.CarUsage.Request
{
    using System;

    public class StartUsageRequestDto
    {
        public Guid ClientId { get; set; }
        public int WalletId { get; set; }
        public Guid CarId { get; set; }
    }
}
