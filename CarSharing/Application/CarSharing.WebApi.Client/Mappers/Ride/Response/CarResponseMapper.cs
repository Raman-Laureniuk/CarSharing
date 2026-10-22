namespace CarSharing.WebApi.Client.Mappers.Ride.Response
{
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.WebApi.Client.Messages.Ride.Response;

    internal static class CarResponseMapper
    {
        public static RideCarResponseMessage ToRideCarResponseMessage(this CarDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new RideCarResponseMessage()
            {
                CarId = dto.CarId,
                Model = dto.Model,
                Color = dto.Color,
                PlateNumber = dto.PlateNumber
            };
        }
    }
}
