namespace CarSharing.WebApi.Management.Messages.Client.Response
{
    using Newtonsoft.Json;

    [JsonObject]
    public class DeactivateClientResponseMessage
    {
        [JsonProperty("success", Required = Required.Always)]
        public bool Success { get; set; }
    }
}
