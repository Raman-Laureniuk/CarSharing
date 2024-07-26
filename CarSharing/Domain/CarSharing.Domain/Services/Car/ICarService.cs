namespace CarSharing.Domain.Services.Car
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.Domain.Dto.Car.Response;

    public interface ICarService
    {
        Task<AddCarResponseDto> AddCarAsync(AddCarRequestDto request);
        Task<UpdateCarResponseDto> UpdateCarAsync(UpdateCarRequestDto request);
        Task<DeleteCarResponseDto> DeleteCarAsync(DeleteCarRequestDto request);
        Task<GetCarsResponseDto> GetCarsAsync(GetCarsRequestDto request);
    }
}
