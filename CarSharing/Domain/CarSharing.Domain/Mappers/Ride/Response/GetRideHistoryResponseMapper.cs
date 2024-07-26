namespace CarSharing.Domain.Mappers.Ride.Response
{
    using System.Collections.Generic;
    using System.Linq;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Tools.Extensions;

    internal static class GetRideHistoryResponseMapper
    {
        public static RideDto ToRideDto(this Ride ride)
        {
            if (ride == null)
            {
                return null;
            }

            return new RideDto()
            {
                RideId = ride.RideId,
                ClientId = ride.ClientId,
                WalletId = ride.WalletId,
                Car = ride.Car.ToCarDto(),
                StartDateUtc = ride.StartDateUtc,
                EndDateUtc = ride.EndDateUtc,
                TotalAmount = ride.TotalAmount,
                Status = ride.Status.ToString()
            };
        }

        public static List<RideDto> ToRideDto(this IEnumerable<Ride> rides)
        {
            return rides
                .OrEmptyIfNull()
                .Select(ToRideDto)
                .ToList();
        }

        public static GetRideHistoryResponseDto ToGetRideHistoryResponseDto(this IEnumerable<Ride> rides)
        {
            return new GetRideHistoryResponseDto()
            {
                Rides = rides.ToRideDto()
            };
        }
    }
}
