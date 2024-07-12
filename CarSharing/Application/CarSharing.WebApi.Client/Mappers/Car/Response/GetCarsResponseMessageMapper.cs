namespace CarSharing.WebApi.Client.Mappers.Car.Response
{
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.WebApi.Client.Messages.Car.Response;

    internal static class GetCarsResponseMessageMapper
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
