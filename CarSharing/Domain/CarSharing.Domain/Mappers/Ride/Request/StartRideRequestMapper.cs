namespace CarSharing.Domain.Mappers.Ride.Request
{
    using System;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Enums.Ride;

    internal static class StartRideRequestMapper
    {
        public static Ride ToRideEntity(this StartRideRequestDto startRideRequestDto)
        {
            if (startRideRequestDto == null)
            {
                throw new ArgumentNullException(nameof(startRideRequestDto));
            }

            return new Ride()
            {
                ClientId = startRideRequestDto.ClientId,
                WalletId = startRideRequestDto.WalletId,
                CarId = startRideRequestDto.CarId,
                StartDateUtc = DateTime.UtcNow,
                EndDateUtc = null,
                TotalAmount = null,
                Status = RideStatus.Active
            };
        }
    }
}
