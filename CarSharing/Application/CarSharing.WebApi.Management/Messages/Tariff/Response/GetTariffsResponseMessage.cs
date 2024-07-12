namespace CarSharing.WebApi.Management.Messages.Tariff.Response
{
    using System.Collections.Generic;

    public class GetTariffsResponseMessage
    {
        public List<TariffMessage> Tariffs { get; set; }
    }
}
