namespace CarSharing.WebApi.Client.Messages.Ride.Request
{
    using System;
    using System.Text.Json.Serialization;
    using CarSharing.WebApi.Common.Validation.Attributes;

    public class StartRideRequestMessage
    {
        [JsonPropertyName("walletId")]
        [JsonRequired]
        [ForbidDefaultValue]
        public int WalletId { get; set; }

        [JsonPropertyName("carId")]
        [JsonRequired]
        [ForbidDefaultValue]
        public Guid CarId { get; set; }
    }
}
