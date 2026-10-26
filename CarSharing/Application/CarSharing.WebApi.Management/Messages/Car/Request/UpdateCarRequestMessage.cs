namespace CarSharing.WebApi.Management.Messages.Car.Request
{
    using System;
    using System.Text.Json.Serialization;
    using CarSharing.WebApi.Common.Validation.Attributes;

    public class UpdateCarRequestMessage
    {
        [JsonPropertyName("carId")]
        [JsonRequired]
        [RequiredNotDefaultValue]
        public Guid CarId { get; set; }

        [JsonPropertyName("model")]
        [JsonRequired]
        public string Model { get; set; }

        [JsonPropertyName("year")]
        [JsonRequired]
        public int? Year { get; set; }

        [JsonPropertyName("color")]
        [JsonRequired]
        public string Color { get; set; }

        [JsonPropertyName("plateNumber")]
        [JsonRequired]
        public string PlateNumber { get; set; }

        [JsonPropertyName("tariffId")]
        [JsonRequired]
        public int? TariffId { get; set; }
    }
}
