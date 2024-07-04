namespace CarSharing.Domain.Dto.CarUsage.Request
{
    using System;

    public class EndUsageRequestDto
    {
        public Guid CarId { get; set; }
        public Guid ClientId { get; set; }
    }
}
