namespace CarSharing.WebApi.Management.Messages.Tariff.Response
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Include)]
    public class GetTariffsResponseMessage
    {
        [JsonProperty("tariffs", Required = Required.AllowNull)]
        public List<TariffMessage> Tariffs { get; set; }
    }
}
