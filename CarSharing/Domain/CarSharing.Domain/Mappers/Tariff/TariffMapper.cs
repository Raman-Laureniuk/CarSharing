namespace CarSharing.Domain.Mappers.Tariff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarSharing.Domain.Dto.Tariff;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Tools.Extensions;

    internal static class TariffMapper
    {
        public static TariffDto ToTariffDto(this Tariff tariff)
        {
            if (tariff == null)
            {
                throw new ArgumentNullException(nameof(tariff));
            }

            return new TariffDto()
            {
                TariffId = tariff.Id,
                PricePerHour = tariff.PricePerHour
            };
        }

        public static List<TariffDto> ToTariffDto(this IEnumerable<Tariff> tariffs)
        {
            return tariffs
                .OrEmptyIfNull()
                .Select(ToTariffDto)
                .ToList();
        }
    }
}
