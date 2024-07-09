namespace CarSharing.Domain.Commands.Ride.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Ride;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Enums.Ride;
    using CarSharing.Domain.Exceptions.Ride;
    using CarSharing.Domain.Mappers.Ride.Request;
    using CarSharing.Domain.Repository.Ride;
    using CarSharing.Domain.RepositoryFactory.Ride;

    internal class StartRideCommandAsync : IStartRideCommandAsync
    {
        private readonly IRideRepositoryFactory _repoFactory;

        public StartRideCommandAsync(IRideRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<StartRideResponseDto> ExecuteAsync(StartRideRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using (IRideRepository repo = _repoFactory.CreateRepository())
            {
                List<Ride> activeRides = await repo.GetRidesForCarAsync(request.ClientId, RideStatus.Active);

                if (activeRides?.Any() ?? false)
                {
                    throw new CarInUseException($"Car {request.CarId} is already in use.");
                }

                Ride ride = request.ToRideEntity();

                await repo.CreateAsync(ride, true);

                return new StartRideResponseDto()
                {
                    Success = true,
                    RideId = ride.Id,
                    StartDateUtc = ride.StartDateUtc
                };
            }
        }
    }
}
