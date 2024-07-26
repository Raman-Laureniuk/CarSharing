namespace CarSharing.WebApi.Management.Mappers.Tariff.Request
{
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.WebApi.Management.Messages.Tariff.Request;

    internal static class AddTariffRequestMapper
    {
        public static AddTariffRequestDto ToAddTariffRequestDto(this AddTariffRequestMessage message)
        {
            if (message == null)
            {
                return null;
            }

            return new AddTariffRequestDto()
            {
                PricePerHour = message.PricePerHour
            };
        }
    }
}
