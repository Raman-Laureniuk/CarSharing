namespace CarSharing.WebApi.Client.Messages.Ride.Response
{
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public class EndRideResponseMessage
    {
        [JsonProperty("success", Required = Required.Always)]
        public bool Success { get; set; }

        [JsonProperty("endDateUtc", Required = Required.Always)]
        public DateTime EndDateUtc { get; set; }

        [JsonProperty("totalAmount", Required = Required.Always)]
        public decimal TotalAmount { get; set; }
    }
}
