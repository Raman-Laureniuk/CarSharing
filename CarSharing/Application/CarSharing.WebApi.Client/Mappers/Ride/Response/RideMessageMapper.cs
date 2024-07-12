namespace CarSharing.WebApi.Client.Mappers.Ride.Response
{
    using System.Collections.Generic;
    using System.Linq;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Tools.Extensions;
    using CarSharing.WebApi.Client.Messages.Ride.Response;

    internal static class RideMessageMapper
    {
        public static RideMessage ToRideMessage(this RideDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new RideMessage()
            {
                RideId = dto.RideId,
                ClientId = dto.ClientId,
                WalletId = dto.WalletId,
                Car = dto.Car.ToCarMessage(),
                StartDateUtc = dto.StartDateUtc,
                EndDateUtc = dto.EndDateUtc,
                TotalAmount = dto.TotalAmount,
                Status = dto.Status
            };
        }

        public static List<RideMessage> ToRideMessage(this IEnumerable<RideDto> dto)
        {
            return dto
                .OrEmptyIfNull()
                .Select(ToRideMessage)
                .ToList();
        }
    }
}
