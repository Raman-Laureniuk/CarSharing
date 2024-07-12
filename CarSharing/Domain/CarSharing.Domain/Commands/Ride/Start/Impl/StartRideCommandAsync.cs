namespace CarSharing.Domain.Commands.Ride.Start.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Ride.Start;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Entities;
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

            Ride ride = request.ToRideEntity();

            using (IRideRepository repo = _repoFactory.CreateRepository())
            {
                await repo.CreateAsync(ride, true);
            }

            return new StartRideResponseDto()
            {
                Success = true,
                RideId = ride.RideId,
                StartDateUtc = ride.StartDateUtc
            };
        }
    }
}
