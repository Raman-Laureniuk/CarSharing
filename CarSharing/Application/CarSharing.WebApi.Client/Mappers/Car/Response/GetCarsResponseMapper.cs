namespace CarSharing.WebApi.Client.Mappers.Car.Response
{
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Client.Messages.Car.Response;
    using CarSharing.WebApi.Common.Mappers;
    using Microsoft.AspNetCore.Mvc;

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
                Cars = dto.Cars.ToCarResponseMessage()
            };
        }

        public static ActionResult<GetCarsResponseMessage> ToActionResult(this Result<GetCarsResponseDto> result)
        {
            return result.ToActionResult(ToGetCarsResponseMessage);
        }
    }
}
