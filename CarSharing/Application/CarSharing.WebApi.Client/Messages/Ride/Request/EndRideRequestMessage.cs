namespace CarSharing.WebApi.Client.Messages.Ride.Request
{
    using Newtonsoft.Json;

    [JsonObject]
    public class EndRideRequestMessage
    {
        [JsonProperty("rideId", Required = Required.Always)]
        public int RideId { get; set; }
    }
}
