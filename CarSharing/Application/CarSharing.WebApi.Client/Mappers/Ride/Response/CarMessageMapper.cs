namespace CarSharing.WebApi.Client.Mappers.Ride.Response
{
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.WebApi.Client.Messages.Ride.Response;

    internal static class CarMessageMapper
    {
        public static CarMessage ToCarMessage(this CarDto carDto)
        {
            if (carDto == null)
            {
                return null;
            }

            return new CarMessage()
            {
                CarId = carDto.CarId,
                Model = carDto.Model,
                Color = carDto.Color,
                PlateNumber = carDto.PlateNumber
            };
        }
    }
}
