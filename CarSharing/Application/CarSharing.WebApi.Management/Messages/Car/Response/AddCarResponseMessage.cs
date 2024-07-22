namespace CarSharing.WebApi.Management.Messages.Car.Response
{
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public class AddCarResponseMessage
    {
        [JsonProperty("carId", Required = Required.Always)]
        public Guid CarId { get; set; }
    }
}
