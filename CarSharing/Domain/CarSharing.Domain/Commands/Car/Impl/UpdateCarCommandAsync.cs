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
                Car car = await repo.GetByIdAsync(request.Id);

                if (car == null)
                {
                    throw new ArgumentOutOfRangeException($"Car {request.Id} not found.");
                }

                car.Model = request.Model;
                car.Year = request.Year;
                car.Color = request.Color;
                car.PlateNumber = request.PlateNumber;
                car.TariffId = request.TariffId;

                await repo.UpdateAsync(car, true);
            }

            return new UpdateCarResponseDto()
            {
                Success = true
            };
        }
    }
}
