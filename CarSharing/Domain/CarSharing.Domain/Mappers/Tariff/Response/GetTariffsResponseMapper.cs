namespace CarSharing.Domain.Mappers.Tariff.Response
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Tools.Extensions;

    internal static class GetTariffsResponseMapper
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

        public static GetTariffsResponseDto ToGetTariffsResponseDto(this IEnumerable<Tariff> tariffs)
        {
            return new GetTariffsResponseDto()
            {
                Tariffs = tariffs.ToTariffDto()
            };
        }
    }
}
