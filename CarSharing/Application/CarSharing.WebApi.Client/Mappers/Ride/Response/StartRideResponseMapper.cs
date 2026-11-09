namespace CarSharing.WebApi.Client.Mappers.Ride.Response
{
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Client.Messages.Ride.Response;
    using CarSharing.WebApi.Common.Mappers;
    using Microsoft.AspNetCore.Mvc;

    internal static class StartRideResponseMapper
    {
        public static StartRideResponseMessage ToStartRideResponseMessage(this StartRideResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new StartRideResponseMessage()
            {
                RideId = dto.RideId,
                StartDateUtc = dto.StartDateUtc
            };
        }

        public static ActionResult<StartRideResponseMessage> ToActionResult(this Result<StartRideResponseDto> result)
        {
            return result.ToActionResult(ToStartRideResponseMessage);
        }
    }
}
