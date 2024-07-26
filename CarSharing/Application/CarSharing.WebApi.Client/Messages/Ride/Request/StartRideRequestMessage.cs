namespace CarSharing.WebApi.Client.Messages.Ride.Request
{
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public class StartRideRequestMessage
    {
        [JsonProperty("walletId", Required = Required.Always)]
        public int WalletId { get; set; }

        [JsonProperty("carId", Required = Required.Always)]
        public Guid CarId { get; set; }
    }
}
