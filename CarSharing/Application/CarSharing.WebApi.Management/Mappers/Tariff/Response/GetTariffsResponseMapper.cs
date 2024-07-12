namespace CarSharing.WebApi.Management.Mappers.Tariff.Response
{
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.WebApi.Management.Messages.Tariff.Response;

    internal static class GetTariffsResponseMapper
    {
        public static GetTariffsResponseMessage ToGetTariffsResponseMessage(this GetTariffsResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new GetTariffsResponseMessage()
            {
                Tariffs = dto.Tariffs.ToTariffMessage()
            };
        }
    }
}
