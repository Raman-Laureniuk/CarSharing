namespace CarSharing.Domain.Dto.Ride.Response
{
    using System;

    public class EndRideResponseDto
    {
        public bool Success { get; set; }
        public DateTime EndDateUtc { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
