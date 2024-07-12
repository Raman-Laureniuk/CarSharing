namespace CarSharing.WebApi.Client.Messages.Ride.Response
{
    using System;

    public class StartRideResponseMessage
    {
        public bool Success { get; set; }
        public int RideId { get; set; }
        public DateTime StartDateUtc { get; set; }
    }
}
