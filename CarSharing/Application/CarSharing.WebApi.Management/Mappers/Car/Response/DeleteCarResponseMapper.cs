namespace CarSharing.WebApi.Management.Mappers.Car.Response
{
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.WebApi.Management.Messages.Car.Response;

    internal static class DeleteCarResponseMapper
    {
        public static DeleteCarResponseMessage ToDeleteCarResponseMessage(this DeleteCarResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new DeleteCarResponseMessage()
            {
                Success = dto.Success
            };
        }
    }
}
