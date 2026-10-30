namespace CarSharing.Domain.Services.Car
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.Domain.Tools.Result;

    public interface ICarService
    {
        Task<Result<AddCarResponseDto>> AddCarAsync(AddCarRequestDto request);
        Task<Result> UpdateCarAsync(UpdateCarRequestDto request);
        Task<Result> DeleteCarAsync(DeleteCarRequestDto request);
        Task<Result<GetCarsResponseDto>> GetCarsAsync(GetCarsRequestDto request);
    }
}
