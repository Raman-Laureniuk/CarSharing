namespace CarSharing.WebApi.Client.Messages.Client.Response
{
    using Newtonsoft.Json;

    [JsonObject]
    public class UpdateClientResponseMessage
    {
        [JsonProperty("success", Required = Required.Always)]
        public bool Success { get; set; }
    }
}
