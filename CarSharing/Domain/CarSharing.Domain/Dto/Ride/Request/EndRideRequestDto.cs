namespace CarSharing.Domain.Dto.Ride.Request
{
    using System;

    public class EndRideRequestDto
    {
        public int RideId { get; set; }
        public Guid ClientId { get; set; }
    }
}
