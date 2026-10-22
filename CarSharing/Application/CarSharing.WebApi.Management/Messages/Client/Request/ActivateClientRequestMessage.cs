namespace CarSharing.WebApi.Management.Messages.Client.Request
{
    using System;
    using System.Text.Json.Serialization;

    public class ActivateClientRequestMessage
    {
        [JsonPropertyName("clientId")]
        [JsonRequired]
        public Guid ClientId { get; set; }
    }
}
