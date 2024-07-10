namespace CarSharing.Domain.Commands.Ride.End
{
    using CarSharing.Domain.Commands.Base;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;

    internal interface IEndRideCommandAsync : ICommandAsync<EndRideRequestDto, EndRideResponseDto>
    {
    }
}
