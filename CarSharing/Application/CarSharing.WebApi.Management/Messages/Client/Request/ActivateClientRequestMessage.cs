namespace CarSharing.WebApi.Management.Messages.Client.Request
{
    using System;
    using System.Text.Json.Serialization;
    using CarSharing.WebApi.Common.Validation.Attributes;

    public class ActivateClientRequestMessage
    {
        [JsonPropertyName("clientId")]
        [JsonRequired]
        [ForbidDefaultValue]
        public Guid ClientId { get; set; }
    }
}
