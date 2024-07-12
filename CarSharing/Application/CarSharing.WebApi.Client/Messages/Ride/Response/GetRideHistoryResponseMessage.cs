namespace CarSharing.WebApi.Client.Messages.Ride.Response
{
    using System.Collections.Generic;

    public class GetRideHistoryResponseMessage
    {
        public List<RideMessage> Rides { get; set; }
    }
}
