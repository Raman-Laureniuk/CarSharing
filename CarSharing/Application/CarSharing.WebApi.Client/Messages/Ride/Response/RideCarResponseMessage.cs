namespace CarSharing.WebApi.Client.Messages.Ride.Response
{
    using System;
    using System.Text.Json.Serialization;

    public class RideCarResponseMessage
    {
        [JsonPropertyName("carId")]
        public Guid CarId { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("plateNumber")]
        public string PlateNumber { get; set; }
    }
}
