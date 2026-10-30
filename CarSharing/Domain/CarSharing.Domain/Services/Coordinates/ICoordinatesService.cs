namespace CarSharing.Domain.Services.Coordinates
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Coordinates.Request;
    using CarSharing.Domain.Tools.Result;

    public interface ICoordinatesService
    {
        Task<Result> AddOrUpdateCoordinatesAsync(AddOrUpdateCoordinatesRequestDto request);
    }
}
