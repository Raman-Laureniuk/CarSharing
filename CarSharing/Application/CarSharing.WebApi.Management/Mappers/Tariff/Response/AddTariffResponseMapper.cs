namespace CarSharing.WebApi.Management.Mappers.Tariff.Response
{
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.WebApi.Management.Messages.Tariff.Response;

    internal static class AddTariffResponseMapper
    {
        public static AddTariffResponseMessage ToAddTariffResponseMessage(this AddTariffResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new AddTariffResponseMessage()
            {
                TariffId = dto.TariffId
            };
        }
    }
}
