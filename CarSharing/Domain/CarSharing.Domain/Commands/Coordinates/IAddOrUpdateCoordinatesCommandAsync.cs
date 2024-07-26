namespace CarSharing.Domain.Commands.Coordinates
{
    using CarSharing.Domain.Commands.Base;
    using CarSharing.Domain.Dto.Coordinates.Request;
    using CarSharing.Domain.Dto.Coordinates.Response;

    internal interface IAddOrUpdateCoordinatesCommandAsync : ICommandAsync<AddOrUpdateCoordinatesRequestDto, AddUpdateCoordinatesResponseDto>
    {
    }
}
