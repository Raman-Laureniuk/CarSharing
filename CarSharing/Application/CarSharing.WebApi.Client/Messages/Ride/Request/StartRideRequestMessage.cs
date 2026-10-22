namespace CarSharing.WebApi.Client.Messages.Ride.Request
{
    using System;
    using System.Text.Json.Serialization;

    public class StartRideRequestMessage
    {
        [JsonPropertyName("walletId")]
        [JsonRequired]
        public int WalletId { get; set; }

        [JsonPropertyName("carId")]
        [JsonRequired]
        public Guid CarId { get; set; }
    }
}
