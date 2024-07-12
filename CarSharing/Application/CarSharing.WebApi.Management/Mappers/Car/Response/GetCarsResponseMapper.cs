namespace CarSharing.WebApi.Management.Mappers.Car.Response
{
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.WebApi.Management.Messages.Car.Response;

    internal static class GetCarsResponseMapper
    {
        public static GetCarsResponseMessage ToGetCarsResponseMessage(this GetCarsResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new GetCarsResponseMessage()
            {
                Cars = dto.Cars.ToCarMessage()
            };
        }
    }
}
