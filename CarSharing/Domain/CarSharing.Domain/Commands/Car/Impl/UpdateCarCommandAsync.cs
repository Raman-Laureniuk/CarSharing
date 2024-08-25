namespace CarSharing.Domain.Commands.Car.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Car;
    using CarSharing.Domain.RepositoryFactory.Car;

    internal class UpdateCarCommandAsync : IUpdateCarCommandAsync
    {
        private readonly ICarRepositoryFactory _repoFactory;

        public UpdateCarCommandAsync(ICarRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<UpdateCarResponseDto> ExecuteAsync(UpdateCarRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using (ICarRepository repo = _repoFactory.CreateRepository())
            {
                Car car = await repo.GetByIdAsync(request.CarId).ConfigureAwait(false);

                if (car == null)
                {
                    throw new ArgumentOutOfRangeException($"Car {request.CarId} not found.");
                }

                car.Model = request.Model ?? car.Model;
                car.Year = request.Year ?? car.Year;
                car.Color = request.Color ?? car.Color;
                car.PlateNumber = request.PlateNumber ?? car.PlateNumber;
                car.TariffId = request.TariffId ?? car.TariffId;

                await repo.UpdateAsync(car, true).ConfigureAwait(false);
            }

            return new UpdateCarResponseDto()
            {
                Success = true
            };
        }
    }
}
