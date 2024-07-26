namespace CarSharing.WebApi.Geo.Messages.Response
{
    using Newtonsoft.Json;

    [JsonObject]
    public class AddOrUpdateCoordinatesResponseMessage
    {
        [JsonProperty("success", Required = Required.Always)]
        public bool Success { get; set; }
    }
}
