namespace CarSharing.WebApi.Management.Mappers.Tariff.Response
{
    using System.Collections.Generic;
    using System.Linq;
    using CarSharing.Domain.Dto.Tariff;
    using CarSharing.Domain.Tools.Extensions;
    using CarSharing.WebApi.Management.Messages.Tariff.Response;

    internal static class TariffMapper
    {
        public static TariffResponseMessage ToTariffResponseMessage(this TariffDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new TariffResponseMessage()
            {
                TariffId = dto.TariffId,
                PricePerHour = dto.PricePerHour
            };
        }

        public static List<TariffResponseMessage> ToTariffResponseMessage(this IEnumerable<TariffDto> dto)
        {
            return dto
                .OrEmptyIfNull()
                .Select(ToTariffResponseMessage)
                .ToList();
        }
    }
}
