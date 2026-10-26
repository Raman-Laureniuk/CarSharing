namespace CarSharing.WebApi.Management.Messages.Client.Request
{
    using System;
    using System.Text.Json.Serialization;
    using CarSharing.WebApi.Common.Validation.Attributes;

    public class DeactivateClientRequestMessage
    {
        [JsonPropertyName("clientId")]
        [JsonRequired]
        [RequiredNotDefaultValue]
        public Guid ClientId { get; set; }
    }
}
