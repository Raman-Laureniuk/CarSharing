namespace CarSharing.WebApi.Client.Messages.Ride.Response
{
    using System;
    using System.Text.Json.Serialization;

    public class EndRideResponseMessage
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("endDateUtc")]
        public DateTime EndDateUtc { get; set; }

        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }
    }
}
