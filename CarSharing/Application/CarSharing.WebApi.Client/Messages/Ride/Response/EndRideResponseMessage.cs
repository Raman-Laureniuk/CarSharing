namespace CarSharing.WebApi.Client.Messages.Ride.Response
{
    using System;

    public class EndRideResponseMessage
    {
        public bool Success { get; set; }
        public DateTime EndDateUtc { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
