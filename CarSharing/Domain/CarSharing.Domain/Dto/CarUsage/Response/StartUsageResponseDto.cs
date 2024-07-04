namespace CarSharing.Domain.Dto.CarUsage.Response
{
    using System;

    public class StartUsageResponseDto
    {
        public bool Success { get; set; }
        public DateTime StartUsageTimeUtc { get; set; }
    }
}
