namespace CarSharing.Domain.Mappers.Tariff.Request
{
    using System;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Entities;

    internal static class AddTariffRequestMapper
    {
        public static Tariff ToTariffEntity(this AddTariffRequestDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new Tariff()
            {
                PricePerHour = dto.PricePerHour
            };
        }
    }
}
