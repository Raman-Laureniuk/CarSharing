namespace CarSharing.WebApi.Client.Mappers.Ride.Response
{
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.WebApi.Client.Messages.Ride.Response;

    internal static class CarMapper
    {
        public static RideCarMessage ToCarMessage(this CarDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new RideCarMessage()
            {
                CarId = dto.CarId,
                Model = dto.Model,
                Color = dto.Color,
                PlateNumber = dto.PlateNumber
            };
        }
    }
}
