namespace CarSharing.WebApi.Client.Mappers.Ride.Response
{
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Client.Messages.Ride.Response;
    using CarSharing.WebApi.Common.Mappers;
    using Microsoft.AspNetCore.Mvc;

    internal static class EndRideResponseMapper
    {
        public static EndRideResponseMessage ToEndRideResponseMessage(this EndRideResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new EndRideResponseMessage()
            {
                EndDateUtc = dto.EndDateUtc,
                TotalAmount = dto.TotalAmount
            };
        }

        public static ActionResult<EndRideResponseMessage> ToActionResult(this Result<EndRideResponseDto> result)
        {
            return result.ToActionResult(ToEndRideResponseMessage);
        }
    }
}
