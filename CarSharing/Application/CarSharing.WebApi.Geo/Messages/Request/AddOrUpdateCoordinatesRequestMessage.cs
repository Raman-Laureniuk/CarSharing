namespace CarSharing.WebApi.Geo.Messages.Request
{
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public class AddOrUpdateCoordinatesRequestMessage
    {
        [JsonProperty("carId", Required = Required.Always)]
        public Guid CarId { get; set; }

        [JsonProperty("latitude", Required = Required.Always)]
        public decimal Latitude { get; set; }

        [JsonProperty("longitude", Required = Required.Always)]
        public decimal Longitude { get; set; }
    }
}
