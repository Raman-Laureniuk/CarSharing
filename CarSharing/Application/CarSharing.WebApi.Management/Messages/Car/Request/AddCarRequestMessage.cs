namespace CarSharing.WebApi.Management.Messages.Car.Request
{
    using System.Text.Json.Serialization;
    using System.ComponentModel.DataAnnotations;
    using CarSharing.WebApi.Common.Validation.Attributes;

    public class AddCarRequestMessage
    {
        [JsonPropertyName("model")]
        [JsonRequired]
        [Required]
        public string Model { get; set; }

        [JsonPropertyName("year")]
        [JsonRequired]
        [RequiredNotDefaultValue]
        public int Year { get; set; }

        [JsonPropertyName("color")]
        [JsonRequired]
        [Required]
        public string Color { get; set; }

        [JsonPropertyName("plateNumber")]
        [JsonRequired]
        [Required]
        public string PlateNumber { get; set; }

        [JsonPropertyName("tariffId")]
        [JsonRequired]
        [RequiredNotDefaultValue]
        public int TariffId { get; set; }
    }
}
