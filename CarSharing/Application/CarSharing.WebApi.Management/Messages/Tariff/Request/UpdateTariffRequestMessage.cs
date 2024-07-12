namespace CarSharing.WebApi.Management.Messages.Tariff.Request
{
    public class UpdateTariffRequestMessage
    {
        public int TariffId { get; set; }
        public decimal PricePerHour { get; set; }
    }
}
