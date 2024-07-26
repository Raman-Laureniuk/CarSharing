namespace CarSharing.Domain.Services.Coordinates
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Coordinates.Request;
    using CarSharing.Domain.Dto.Coordinates.Response;

    public interface ICoordinatesService
    {
        Task<AddUpdateCoordinatesResponseDto> AddOrUpdateCoordinatesAsync(AddOrUpdateCoordinatesRequestDto request);
    }
}
