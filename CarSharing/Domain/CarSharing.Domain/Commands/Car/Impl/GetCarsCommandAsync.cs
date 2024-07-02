namespace CarSharing.Domain.Commands.Car.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Mappers.Car.Response;
    using CarSharing.Domain.Repository.Car;
    using CarSharing.Domain.RepositoryFactory.Car;

    internal class GetCarsCommandAsync : IGetCarsCommandAsync
    {
        private readonly ICarRepositoryFactory _repoFactory;

        public GetCarsCommandAsync(ICarRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<GetCarsResponseDto> ExecuteAsync(GetCarsRequestDto request)
        {
            using (ICarRepository repo = _repoFactory.CreateRepository())
            {
                List<Car> cars = await repo.GetAllAsync();  // TODO: optimize with Include and Offset/Limit

                return cars.ToGetCarsResponseDto();
            }
        }
    }
}
