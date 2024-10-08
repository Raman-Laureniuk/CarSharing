﻿namespace CarSharing.Domain.Commands.Car.Impl
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
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Car car = request.ToCarEntity(Guid.NewGuid());

            using (ICarRepository repo = _repoFactory.CreateRepository())
            {
                await repo.CreateAsync(car, true).ConfigureAwait(false);
            }

            return new AddCarResponseDto()
            {
                CarId = car.CarId
            };
        }
    }
}
