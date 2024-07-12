namespace CarSharing.WebApi.Client.Mappers.Ride.Request
{
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.WebApi.Client.Messages.Ride.Request;

    internal static class StartRideRequestMessageMapper
    {
        public static StartRideRequestDto ToStartRideRequestDto(this StartRideRequestMessage message)
        {
            if (message == null)
            {
                return null;
            }

            return new StartRideRequestDto()
            {
                ClientId = message.ClientId,
                WalletId = message.WalletId,
                CarId = message.CarId
            };
        }
    }
}
