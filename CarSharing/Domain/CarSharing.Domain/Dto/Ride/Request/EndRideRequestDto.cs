namespace CarSharing.Domain.Dto.Ride.Request
{
    using System;

    public class EndRideRequestDto
    {
        public Guid CarId { get; set; }
        public Guid ClientId { get; set; }
    }
}
