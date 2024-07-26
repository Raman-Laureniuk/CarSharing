namespace CarSharing.WebApi.Client.Mappers.Ride.Request
{
    using System;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.WebApi.Client.Messages.Ride.Request;

    internal static class EndRideRequestMapper
    {
        public static EndRideRequestDto ToEndRideRequestDto(this EndRideRequestMessage message, Guid clientId)
        {
            if (message == null)
            {
                return null;
            }

            return new EndRideRequestDto()
            {
                RideId = message.RideId,
                ClientId = clientId
            };
        }
    }
}
