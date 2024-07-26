namespace CarSharing.Domain.Services.Coordinates.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Coordinates;
    using CarSharing.Domain.Dto.Coordinates.Request;
    using CarSharing.Domain.Dto.Coordinates.Response;

    internal class CoordinatesService : ICoordinatesService
    {
        private readonly IAddOrUpdateCoordinatesCommandAsync _addOrUpdateCoordinatesCommand;

        public CoordinatesService(IAddOrUpdateCoordinatesCommandAsync updateCoordinatesCommand)
        {
            _addOrUpdateCoordinatesCommand = updateCoordinatesCommand ?? throw new ArgumentNullException(nameof(updateCoordinatesCommand));
        }

        public Task<AddUpdateCoordinatesResponseDto> AddOrUpdateCoordinatesAsync(AddOrUpdateCoordinatesRequestDto request)
        {
            return _addOrUpdateCoordinatesCommand.ExecuteAsync(request);
        }
    }
}
