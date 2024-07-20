namespace CarSharing.WebApi.Client.Mappers.Ride.Request
{
    using System;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.WebApi.Client.Messages.Ride.Request;

    internal static class StartRideRequestMapper
    {
        public static StartRideRequestDto ToStartRideRequestDto(this StartRideRequestMessage message, Guid clientId)
        {
            if (message == null)
            {
                return null;
            }

            return new StartRideRequestDto()
            {
                ClientId = clientId,
                WalletId = message.WalletId,
                CarId = message.CarId
            };
        }
    }
}
