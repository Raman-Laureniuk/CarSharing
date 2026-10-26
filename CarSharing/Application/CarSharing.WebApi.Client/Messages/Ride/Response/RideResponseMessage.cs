namespace CarSharing.WebApi.Client.Messages.Ride.Response
{
    using System;
    using System.Text.Json.Serialization;

    public class RideResponseMessage
    {
        [JsonPropertyName("rideId")]
        public int RideId { get; set; }

        [JsonPropertyName("clientId")]
        public Guid ClientId { get; set; }

        [JsonPropertyName("walletId")]
        public int WalletId { get; set; }

        [JsonPropertyName("car")]
        public RideCarResponseMessage Car { get; set; }

        [JsonPropertyName("startDateUtc")]
        public DateTime StartDateUtc { get; set; }

        [JsonPropertyName("endDateUtc")]
        public DateTime? EndDateUtc { get; set; }

        [JsonPropertyName("totalAmount")]
        public decimal? TotalAmount { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
