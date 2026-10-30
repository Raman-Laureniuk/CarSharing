namespace CarSharing.Domain.Commands.Coordinates
{
    using CarSharing.Domain.Commands.Base;
    using CarSharing.Domain.Dto.Coordinates.Request;

    internal interface IAddOrUpdateCoordinatesCommandAsync : ICommandAsync<AddOrUpdateCoordinatesRequestDto>
    {
    }
}
