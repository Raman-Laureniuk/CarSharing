namespace CarSharing.WebApi.Management.Mappers.Car.Response
{
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.WebApi.Management.Messages.Car.Response;

    internal static class AddCarResponseMapper
    {
        public static AddCarResponseMessage ToAddCarResponseMessage(this AddCarResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new AddCarResponseMessage()
            {
                CarId = dto.CarId
            };
        }
    }
}
