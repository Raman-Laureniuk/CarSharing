namespace CarSharing.WebApi.Management.Messages.Car.Response
{
    using Newtonsoft.Json;

    [JsonObject]
    public class DeleteCarResponseMessage
    {
        [JsonProperty("success", Required = Required.Always)]
        public bool Success { get; set; }
    }
}
