namespace CarSharing.WebApi.Management.Mappers.Car.Request
{
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.WebApi.Management.Messages.Car.Request;

    internal static class UpdateCarRequestMapper
    {
        public static UpdateCarRequestDto ToUpdateCarRequestDto(this UpdateCarRequestMessage message)
        {
            if (message == null)
            {
                return null;
            }

            return new UpdateCarRequestDto()
            {
                Id = message.Id,
                Model = message.Model,
                Year = message.Year,
                Color = message.Color,
                PlateNumber = message.PlateNumber,
                TariffId = message.TariffId
            };
        }
    }
}
