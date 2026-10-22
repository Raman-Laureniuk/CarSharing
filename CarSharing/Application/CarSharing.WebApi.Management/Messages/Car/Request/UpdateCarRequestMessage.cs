namespace CarSharing.WebApi.Management.Messages.Car.Request
{
    using System;
    using System.Text.Json.Serialization;

    public class UpdateCarRequestMessage
    {
        [JsonPropertyName("carId")]
        [JsonRequired]
        public Guid CarId { get; set; }

        [JsonPropertyName("model")]
        [JsonRequired]  // Allow null
        public string Model { get; set; }

        [JsonPropertyName("year")]
        [JsonRequired]  // Allow null
        public int? Year { get; set; }

        [JsonPropertyName("color")]
        [JsonRequired]  // Allow null
        public string Color { get; set; }

        [JsonPropertyName("plateNumber")]
        [JsonRequired]  // Allow null
        public string PlateNumber { get; set; }

        [JsonPropertyName("tariffId")]
        [JsonRequired]  // Allow null
        public int? TariffId { get; set; }
    }
}
