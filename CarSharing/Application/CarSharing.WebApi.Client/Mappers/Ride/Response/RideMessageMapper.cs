namespace CarSharing.WebApi.Client.Mappers.Ride.Response
{
    using System.Collections.Generic;
    using System.Linq;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Tools.Extensions;
    using CarSharing.WebApi.Client.Messages.Ride.Response;

    internal static class RideMessageMapper
    {
        public static RideMessage ToRideMessage(this RideDto rideDto)
        {
            if (rideDto == null)
            {
                return null;
            }

            return new RideMessage()
            {
                RideId = rideDto.RideId,
                ClientId = rideDto.ClientId,
                WalletId = rideDto.WalletId,
                Car = rideDto.Car.ToCarMessage(),
                StartDateUtc = rideDto.StartDateUtc,
                EndDateUtc = rideDto.EndDateUtc,
                TotalAmount = rideDto.TotalAmount,
                Status = rideDto.Status
            };
        }

        public static List<RideMessage> ToRideMessage(this IEnumerable<RideDto> rideDto)
        {
            return rideDto
                .OrEmptyIfNull()
                .Select(ToRideMessage)
                .ToList();
        }
    }
}
