namespace CarSharing.Domain.Commands.Ride.GetHistory
{
    using CarSharing.Domain.Commands.Base;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;

    internal interface IGetRideHistoryCommandAsync : ICommandAsync<GetRideHistoryRequestDto, GetRideHistoryResponseDto>
    {
    }
}
