namespace CarSharing.WebApi.Client.Mappers.Ride.Response
{
    using System.Collections.Generic;
    using System.Linq;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Tools.Extensions;
    using CarSharing.WebApi.Client.Messages.Ride.Response;

    internal static class RideMapper
    {
        public static RideResponseMessage ToRideResponseMessage(this RideDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new RideResponseMessage()
            {
                RideId = dto.RideId,
                ClientId = dto.ClientId,
                WalletId = dto.WalletId,
                Car = dto.Car.ToRideCarResponseMessage(),
                StartDateUtc = dto.StartDateUtc,
                EndDateUtc = dto.EndDateUtc,
                TotalAmount = dto.TotalAmount,
                Status = dto.Status
            };
        }

        public static List<RideResponseMessage> ToRideResponseMessage(this IEnumerable<RideDto> dto)
        {
            return dto
                .OrEmptyIfNull()
                .Select(ToRideResponseMessage)
                .ToList();
        }
    }
}
