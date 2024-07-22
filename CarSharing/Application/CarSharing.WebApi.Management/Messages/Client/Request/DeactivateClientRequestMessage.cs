namespace CarSharing.WebApi.Management.Messages.Client.Request
{
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public class DeactivateClientRequestMessage
    {
        [JsonProperty("clientId", Required = Required.Always)]
        public Guid ClientId { get; set; }
    }
}
