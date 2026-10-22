namespace CarSharing.WebApi.Management.Messages.Client.Response
{
    using System;
    using System.Text.Json.Serialization;

    public class ClientResponseMessage
    {
        [JsonPropertyName("clientId")]
        public Guid ClientId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("licenseNumber")]
        public string LicenseNumber { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("isBlocked")]
        public bool IsBlocked { get; set; }
    }
}
