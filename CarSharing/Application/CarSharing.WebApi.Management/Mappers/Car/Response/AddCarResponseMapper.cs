namespace CarSharing.WebApi.Management.Mappers.Car.Response
{
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Common.Mappers;
    using CarSharing.WebApi.Management.Messages.Car.Response;
    using Microsoft.AspNetCore.Mvc;

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

        public static ActionResult<AddCarResponseMessage> ToActionResult(this Result<AddCarResponseDto> result)
        {
            return result.ToActionResult(ToAddCarResponseMessage);
        }
    }
}
