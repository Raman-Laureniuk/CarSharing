namespace CarSharing.Domain.Commands.Car.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.Domain.Dto.Car.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Mappers.Car.Request;
    using CarSharing.Domain.Repository.Car;
    using CarSharing.Domain.RepositoryFactory.Car;

    internal class AddCarCommandAsync : IAddCarCommandAsync
    {
        private readonly ICarRepositoryFactory _repoFactory;

        public AddCarCommandAsync(ICarRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<AddCarResponseDto> ExecuteAsync(AddCarRequestDto request)
        {
            Car car = request.ToCarEntity();

            using (ICarRepository repo = _repoFactory.CreateRepository())
            {
                await repo.CreateAsync(car, true);
            }

            return new AddCarResponseDto()
            {
                Id = car.Id
            };
        }
    }
}
