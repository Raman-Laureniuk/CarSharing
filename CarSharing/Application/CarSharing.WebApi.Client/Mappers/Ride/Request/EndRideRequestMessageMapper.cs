namespace CarSharing.WebApi.Client.Mappers.Ride.Request
{
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.WebApi.Client.Messages.Ride.Request;

    internal static class EndRideRequestMessageMapper
    {
        public static EndRideRequestDto ToEndRideRequestDto(this EndRideRequestMessage message)
        {
            if (message == null)
            {
                return null;
            }

            return new EndRideRequestDto()
            {
                RideId = message.RideId,
                ClientId = message.ClientId
            };
        }
    }
}
