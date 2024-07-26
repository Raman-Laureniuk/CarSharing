namespace CarSharing.WebApi.Management.Mappers.Car.Request
{
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.WebApi.Management.Messages.Car.Request;

    internal static class AddCarRequestMapper
    {
        public static AddCarRequestDto ToAddCarRequestDto(this AddCarRequestMessage message)
        {
            if (message == null)
            {
                return null;
            }

            return new AddCarRequestDto()
            {
                Model = message.Model,
                Year = message.Year,
                Color = message.Color,
                PlateNumber = message.PlateNumber,
                TariffId = message.TariffId
            };
        }
    }
}
