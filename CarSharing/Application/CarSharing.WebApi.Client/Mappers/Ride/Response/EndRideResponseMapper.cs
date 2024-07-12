namespace CarSharing.WebApi.Client.Mappers.Ride.Response
{
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.WebApi.Client.Messages.Ride.Response;

    internal static class EndRideResponseMapper
    {
        public static EndRideResponseMessage ToEndRideResponseMessage(this EndRideResponseDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new EndRideResponseMessage()
            {
                Success = dto.Success,
                EndDateUtc = dto.EndDateUtc,
                TotalAmount = dto.TotalAmount
            };
        }
    }
}
