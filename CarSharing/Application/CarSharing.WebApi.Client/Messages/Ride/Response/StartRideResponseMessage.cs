namespace CarSharing.WebApi.Client.Messages.Ride.Response
{
    using System;
    using System.Text.Json.Serialization;

    public class StartRideResponseMessage
    {
        [JsonPropertyName("rideId")]
        public int RideId { get; set; }

        [JsonPropertyName("startDateUtc")]
        public DateTime StartDateUtc { get; set; }
    }
}
