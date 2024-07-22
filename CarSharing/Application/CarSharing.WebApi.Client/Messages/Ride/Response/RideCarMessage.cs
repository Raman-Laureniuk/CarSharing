namespace CarSharing.WebApi.Client.Messages.Ride.Response
{
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public class RideCarMessage
    {
        [JsonProperty("carId", Required = Required.Always)]
        public Guid CarId { get; set; }

        [JsonProperty("model", Required = Required.Always)]
        public string Model { get; set; }

        [JsonProperty("color", Required = Required.Always)]
        public string Color { get; set; }

        [JsonProperty("plateNumber", Required = Required.Always)]
        public string PlateNumber { get; set; }
    }
}
