namespace CarSharing.Domain.Dto.Ride.Response
{
    using System;

    public class StartRideResponseDto
    {
        public bool Success { get; set; }
        public int RideId { get; set; }
        public DateTime StartDateUtc { get; set; }
    }
}
