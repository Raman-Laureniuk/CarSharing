namespace CarSharing.WebApi.Management.Messages.Car.Response
{
    using System;
    using System.Text.Json.Serialization;

    public class CarResponseMessage
    {
        [JsonPropertyName("carId")]
        public Guid CarId { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("plateNumber")]
        public string PlateNumber { get; set; }

        [JsonPropertyName("pricePerHour")]
        public decimal PricePerHour { get; set; }

        [JsonPropertyName("latitude")]
        public decimal Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public decimal Longitude { get; set; }
    }
}
