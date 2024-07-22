namespace CarSharing.WebApi.Management.Messages.Car.Request
{
    using Newtonsoft.Json;

    [JsonObject]
    public class AddCarRequestMessage
    {
        [JsonProperty("model", Required = Required.Always)]
        public string Model { get; set; }

        [JsonProperty("year", Required = Required.Always)]
        public int Year { get; set; }

        [JsonProperty("color", Required = Required.Always)]
        public string Color { get; set; }

        [JsonProperty("plateNumber", Required = Required.Always)]
        public string PlateNumber { get; set; }

        [JsonProperty("tariffId", Required = Required.Always)]
        public int TariffId { get; set; }
    }
}
