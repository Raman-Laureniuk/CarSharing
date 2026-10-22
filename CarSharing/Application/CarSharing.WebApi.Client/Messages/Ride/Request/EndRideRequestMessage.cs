namespace CarSharing.WebApi.Client.Messages.Ride.Request
{
    using System.Text.Json.Serialization;

    public class EndRideRequestMessage
    {
        [JsonPropertyName("rideId")]
        [JsonRequired]
        public int RideId { get; set; }
    }
}
