namespace CarSharing.Domain.Dto.Tariff.Request
{
    public class UpdateTariffRequestDto
    {
        public int TariffId { get; set; }
        public decimal PricePerHour { get; set; }
    }
}
