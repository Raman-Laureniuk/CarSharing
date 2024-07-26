namespace CarSharing.Domain.Mappers.Tariff.Response
{
    using System.Collections.Generic;
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.Domain.Entities;

    internal static class GetTariffsResponseMapper
    {
        public static GetTariffsResponseDto ToGetTariffsResponseDto(this IEnumerable<Tariff> tariffs)
        {
            return new GetTariffsResponseDto()
            {
                Tariffs = tariffs.ToTariffDto()
            };
        }
    }
}
