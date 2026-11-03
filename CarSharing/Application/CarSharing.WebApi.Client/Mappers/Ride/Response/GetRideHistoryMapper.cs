namespace CarSharing.WebApi.Client.Mappers.Ride.Response
{
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Tools.Result;
    using CarSharing.WebApi.Client.Messages.Ride.Response;
    using CarSharing.WebApi.Common.Mappers;
    using Microsoft.AspNetCore.Mvc;

    internal static class GetRideHistoryMapper
    {
        public static GetRideHistoryResponseMessage ToGetRideHistoryResponseMessage(this GetRideHistoryResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new GetRideHistoryResponseMessage()
            {
                Rides = dto.Rides.ToRideResponseMessage()
            };
        }

        public static ActionResult<GetRideHistoryResponseMessage> ToActionResult(this Result<GetRideHistoryResponseDto> result)
        {
            return result.ToActionResult(ToGetRideHistoryResponseMessage);
        }
    }
}
