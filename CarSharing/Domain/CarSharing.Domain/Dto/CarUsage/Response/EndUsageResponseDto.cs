namespace CarSharing.Domain.Dto.CarUsage.Response
{
    using System;

    public class EndUsageResponseDto
    {
        public bool Success { get; set; }
        public DateTime EndUsageTimeUtc { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
