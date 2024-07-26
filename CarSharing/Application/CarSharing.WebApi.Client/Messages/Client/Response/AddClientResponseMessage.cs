namespace CarSharing.WebApi.Client.Messages.Client.Response
{
    using Newtonsoft.Json;

    [JsonObject]
    public class AddClientResponseMessage
    {
        [JsonProperty("success", Required = Required.Always)]
        public bool Success { get; set; }
    }
}
