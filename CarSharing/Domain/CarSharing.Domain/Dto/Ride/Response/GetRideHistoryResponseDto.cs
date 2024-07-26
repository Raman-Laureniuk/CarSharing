namespace CarSharing.Domain.Dto.Ride.Response
{
    using System.Collections.Generic;

    public class GetRideHistoryResponseDto
    {
        public List<RideDto> Rides { get; set; }
    }
}
