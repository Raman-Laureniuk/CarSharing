namespace CarSharing.WebApi.Management.Messages.Client.Request
{
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public class ActivateClientRequestMessage
    {
        [JsonProperty("clientId", Required = Required.Always)]
        public Guid ClientId { get; set; }
    }
}
