namespace CarSharing.Domain.Commands.Ride
{
    using CarSharing.Domain.Commands.Base;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;

    internal interface IStartRideCommandAsync : ICommandAsync<StartRideRequestDto, StartRideResponseDto>
    {
    }
}
