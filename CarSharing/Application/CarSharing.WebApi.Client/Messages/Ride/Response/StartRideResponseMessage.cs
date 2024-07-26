namespace CarSharing.WebApi.Client.Messages.Ride.Response
{
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public class StartRideResponseMessage
    {
        [JsonProperty("success", Required = Required.Always)]
        public bool Success { get; set; }

        [JsonProperty("rideId", Required = Required.Always)]
        public int RideId { get; set; }

        [JsonProperty("startDateUtc", Required = Required.Always)]
        public DateTime StartDateUtc { get; set; }
    }
}
