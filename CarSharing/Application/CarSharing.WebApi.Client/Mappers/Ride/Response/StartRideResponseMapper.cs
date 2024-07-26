namespace CarSharing.WebApi.Client.Mappers.Ride.Response
{
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.WebApi.Client.Messages.Ride.Response;

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
                Success = dto.Success,
                RideId = dto.RideId,
                StartDateUtc = dto.StartDateUtc
            };
        }
    }
}
