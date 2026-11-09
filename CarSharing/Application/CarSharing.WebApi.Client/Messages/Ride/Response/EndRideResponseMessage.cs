namespace CarSharing.WebApi.Client.Messages.Ride.Response
{
    using System;
    using System.Text.Json.Serialization;

    public class EndRideResponseMessage
    {
        [JsonPropertyName("endDateUtc")]
        public DateTime EndDateUtc { get; set; }

        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }
    }
}
