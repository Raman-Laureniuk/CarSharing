namespace CarSharing.WebApi.Management.Mappers.Tariff.Request
{
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.WebApi.Management.Messages.Tariff.Request;

    internal static class UpdateTariffRequestMapper
    {
        public static UpdateTariffRequestDto ToUpdateTariffRequestDto(this UpdateTariffRequestMessage message)
        {
            if (message == null)
            {
                return null;
            }

            return new UpdateTariffRequestDto()
            {
                TariffId = message.TariffId,
                PricePerHour = message.PricePerHour
            };
        }
    }
}
