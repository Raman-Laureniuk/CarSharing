namespace CarSharing.Domain.Dto.CarUsage.Response
{
    using System;

    public class StartUsageResponseDto
    {
        public bool Success { get; set; }
        public int CarUsageId { get; set; }
        public DateTime StartUsageTimeUtc { get; set; }
    }
}
