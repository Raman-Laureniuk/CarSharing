namespace CarSharing.WebApi.Client.Messages.Ride.Request
{
    using System.Text.Json.Serialization;
    using CarSharing.WebApi.Common.Validation.Attributes;

    public class EndRideRequestMessage
    {
        [JsonPropertyName("rideId")]
        [JsonRequired]
        [RequiredNotDefaultValue]
        public int RideId { get; set; }
    }
}
