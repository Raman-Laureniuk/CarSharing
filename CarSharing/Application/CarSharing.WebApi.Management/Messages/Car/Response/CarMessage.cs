namespace CarSharing.WebApi.Management.Messages.Car.Response
{
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public class CarMessage
    {
        [JsonProperty("carId", Required = Required.Always)]
        public Guid CarId { get; set; }

        [JsonProperty("model", Required = Required.Always)]
        public string Model { get; set; }

        [JsonProperty("year", Required = Required.Always)]
        public int Year { get; set; }

        [JsonProperty("color", Required = Required.Always)]
        public string Color { get; set; }

        [JsonProperty("plateNumber", Required = Required.Always)]
        public string PlateNumber { get; set; }

        [JsonProperty("pricePerHour", Required = Required.Always)]
        public decimal PricePerHour { get; set; }

        [JsonProperty("latitude", Required = Required.Always)]
        public decimal Latitude { get; set; }

        [JsonProperty("longitude", Required = Required.Always)]
        public decimal Longitude { get; set; }
    }
}
