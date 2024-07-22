namespace CarSharing.WebApi.Client.Messages.Ride.Response
{
    using System;
    using Newtonsoft.Json;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Include)]
    public class RideMessage
    {
        [JsonProperty("rideId", Required = Required.Always)]
        public int RideId { get; set; }

        [JsonProperty("clientId", Required = Required.Always)]
        public Guid ClientId { get; set; }

        [JsonProperty("walletId", Required = Required.Always)]
        public int WalletId { get; set; }

        [JsonProperty("car", Required = Required.Always)]
        public RideCarMessage Car { get; set; }

        [JsonProperty("startDateUtc", Required = Required.Always)]
        public DateTime StartDateUtc { get; set; }

        [JsonProperty("endDateUtc", Required = Required.AllowNull)]
        public DateTime? EndDateUtc { get; set; }

        [JsonProperty("totalAmount", Required = Required.AllowNull)]
        public decimal? TotalAmount { get; set; }

        [JsonProperty("status", Required = Required.Always)]
        public string Status { get; set; }
    }
}
