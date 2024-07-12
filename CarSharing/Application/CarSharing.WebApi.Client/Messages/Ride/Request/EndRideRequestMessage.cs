namespace CarSharing.WebApi.Client.Messages.Ride.Request
{
    using System;

    public class EndRideRequestMessage
    {
        public int RideId { get; set; }
        public Guid ClientId { get; set; }  // TODO: Remove ClientId after auth implementation
    }
}
