namespace CarSharing.Domain.Mappers.Tariff
{
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
                return null;
            }

            return new TariffDto()
            {
                TariffId = tariff.TariffId,
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
