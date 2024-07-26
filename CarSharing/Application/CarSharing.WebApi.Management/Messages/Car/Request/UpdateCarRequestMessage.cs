namespace CarSharing.WebApi.Management.Messages.Car.Request
{
    using System;
    using Newtonsoft.Json;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Include)]
    public class UpdateCarRequestMessage
    {
        [JsonProperty("carId", Required = Required.Always)]
        public Guid CarId { get; set; }

        [JsonProperty("model", Required = Required.AllowNull)]
        public string Model { get; set; }

        [JsonProperty("year", Required = Required.AllowNull)]
        public int? Year { get; set; }

        [JsonProperty("color", Required = Required.AllowNull)]
        public string Color { get; set; }

        [JsonProperty("plateNumber", Required = Required.AllowNull)]
        public string PlateNumber { get; set; }

        [JsonProperty("tariffId", Required = Required.AllowNull)]
        public int? TariffId { get; set; }
    }
}
