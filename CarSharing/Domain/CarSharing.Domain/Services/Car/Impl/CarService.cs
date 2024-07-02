namespace CarSharing.Domain.Services.Car.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Car;
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.Domain.Dto.Car.Response;

    internal class CarService : ICarService
    {
        private readonly IAddCarCommandAsync _addCarCommand;
        private readonly IDeleteCarCommandAsync _deleteCarCommand;
        private readonly IGetCarsCommandAsync _getCarsCommand;
        private readonly IUpdateCarCommandAsync _updateCarCommand;

        public CarService(IAddCarCommandAsync addCarCommand,
            IDeleteCarCommandAsync deleteCarCommand,
            IGetCarsCommandAsync getCarsCommand,
            IUpdateCarCommandAsync updateCarCommand)
        {
            _addCarCommand = addCarCommand ?? throw new ArgumentNullException(nameof(addCarCommand));
            _deleteCarCommand = deleteCarCommand ?? throw new ArgumentNullException(nameof(deleteCarCommand));
            _getCarsCommand = getCarsCommand ?? throw new ArgumentNullException(nameof(getCarsCommand));
            _updateCarCommand = updateCarCommand ?? throw new ArgumentNullException(nameof(updateCarCommand));
        }

        public Task<AddCarResponseDto> AddCarAsync(AddCarRequestDto request)
        {
            return _addCarCommand.ExecuteAsync(request);
        }

        public Task<DeleteCarResponseDto> DeleteCarAsync(DeleteCarRequestDto request)
        {
            return _deleteCarCommand.ExecuteAsync(request);
        }

        public Task<GetCarsResponseDto> GetCarsAsync(GetCarsRequestDto request)
        {
            return _getCarsCommand.ExecuteAsync(request);
        }

        public Task<UpdateCarResponseDto> UpdateCarAsync(UpdateCarRequestDto request)
        {
            return _updateCarCommand.ExecuteAsync(request);
        }
    }
}
