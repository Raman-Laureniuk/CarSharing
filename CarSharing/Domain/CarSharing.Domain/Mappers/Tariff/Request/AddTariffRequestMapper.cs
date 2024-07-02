namespace CarSharing.Domain.Mappers.Tariff.Request
{
    using System;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Entities;

    internal static class AddTariffRequestMapper
    {
        public static Tariff ToTariffEntity(this AddTariffRequestDto addTariffRequestDto)
        {
            if (addTariffRequestDto == null)
            {
                throw new ArgumentNullException(nameof(addTariffRequestDto));
            }

            return new Tariff()
            {
                PricePerHour = addTariffRequestDto.PricePerHour
            };
        }
    }
}
