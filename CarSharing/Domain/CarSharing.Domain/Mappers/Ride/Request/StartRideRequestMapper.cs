namespace CarSharing.Domain.Mappers.Ride.Request
{
    using System;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Enums.Ride;

    internal static class StartRideRequestMapper
    {
        public static Ride ToRideEntity(this StartRideRequestDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Ride()
            {
                ClientId = dto.ClientId,
                WalletId = dto.WalletId,
                CarId = dto.CarId,
                StartDateUtc = DateTime.UtcNow,
                EndDateUtc = null,
                TotalAmount = null,
                Status = RideStatus.Active
            };
        }
    }
}
