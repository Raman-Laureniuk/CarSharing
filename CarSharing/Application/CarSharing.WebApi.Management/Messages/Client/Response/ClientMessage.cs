namespace CarSharing.WebApi.Management.Messages.Client.Response
{
    using System;
    using Newtonsoft.Json;

    [JsonObject]
    public class ClientMessage
    {
        [JsonProperty("clientId", Required = Required.Always)]
        public Guid ClientId { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("surname", Required = Required.Always)]
        public string Surname { get; set; }

        [JsonProperty("licenseNumber", Required = Required.Always)]
        public string LicenseNumber { get; set; }

        [JsonProperty("phoneNumber", Required = Required.Always)]
        public string PhoneNumber { get; set; }

        [JsonProperty("email", Required = Required.Always)]
        public string Email { get; set; }

        [JsonProperty("isActive", Required = Required.Always)]
        public bool IsActive { get; set; }

        [JsonProperty("isBlocked", Required = Required.Always)]
        public bool IsBlocked { get; set; }
    }
}
