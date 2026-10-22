namespace CarSharing.WebApi.Geo.Messages.Coordinates.Request
{
    using System;
    using System.Text.Json.Serialization;

    public class AddOrUpdateCoordinatesRequestMessage
    {
        [JsonPropertyName("carId")]
        [JsonRequired]
        public Guid CarId { get; set; }

        [JsonPropertyName("latitude")]
        [JsonRequired]
        public decimal Latitude { get; set; }

        [JsonPropertyName("longitude")]
        [JsonRequired]
        public decimal Longitude { get; set; }
    }
}
