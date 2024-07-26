namespace CarSharing.Domain.Dto.Tariff.Request
{
    using System;

    public class CalculatePriceRequestDto
    {
        public TariffDto Tariff { get; set; }
        public TimeSpan RidePeriod { get; set; }
    }
}
