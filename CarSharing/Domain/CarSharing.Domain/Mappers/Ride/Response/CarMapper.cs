namespace CarSharing.Domain.Mappers.Ride.Response
{
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Entities;

    internal static class CarMapper
    {
        public static CarDto ToCarDto(this Car car)
        {
            if (car == null)
            {
                return null;
            }

            return new CarDto()
            {
                CarId = car.CarId,
                Model = car.Model,
                Color = car.Color,
                PlateNumber = car.PlateNumber
            };
        }
    }
}
