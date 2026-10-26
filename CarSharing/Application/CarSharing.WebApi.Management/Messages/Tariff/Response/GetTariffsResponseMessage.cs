namespace CarSharing.WebApi.Management.Messages.Tariff.Response
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class GetTariffsResponseMessage
    {
        [JsonPropertyName("tariffs")]
        public List<TariffResponseMessage> Tariffs { get; set; }
    }
}
