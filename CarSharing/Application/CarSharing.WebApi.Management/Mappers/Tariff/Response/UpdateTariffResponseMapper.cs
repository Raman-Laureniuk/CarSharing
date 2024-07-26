namespace CarSharing.WebApi.Management.Mappers.Tariff.Response
{
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.WebApi.Management.Messages.Tariff.Response;

    internal static class UpdateTariffResponseMapper
    {
        public static UpdateTariffResponseMessage ToUpdateTariffResponseMessage(this UpdateTariffResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new UpdateTariffResponseMessage()
            {
                Success = dto.Success
            };
        }
    }
}
