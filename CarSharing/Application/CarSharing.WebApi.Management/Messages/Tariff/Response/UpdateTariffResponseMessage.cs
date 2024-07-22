namespace CarSharing.WebApi.Management.Messages.Tariff.Response
{
    using Newtonsoft.Json;

    [JsonObject]
    public class UpdateTariffResponseMessage
    {
        [JsonProperty("success", Required = Required.Always)]
        public bool Success { get; set; }
    }
}
