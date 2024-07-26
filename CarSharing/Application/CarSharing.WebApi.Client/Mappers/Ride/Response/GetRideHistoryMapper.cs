namespace CarSharing.WebApi.Client.Mappers.Ride.Response
{
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.WebApi.Client.Messages.Ride.Response;

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
                Rides = dto.Rides.ToRideMessage()
            };
        }
    }
}
