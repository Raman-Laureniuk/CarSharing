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
    using CarSharing.Domain.Repository.Ride;
    using CarSharing.Domain.RepositoryFactory.Ride;

    internal class EndRideCommandAsync : IEndRideCommandAsync
    {
        private readonly IRideRepositoryFactory _repoFactory;

        public EndRideCommandAsync(IRideRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<EndRideResponseDto> ExecuteAsync(EndRideRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            
            using (IRideRepository repo = _repoFactory.CreateRepository())
            {
                List<Ride> rides = await repo.GetRidesAsync(request.CarId, RideStatus.Active);
                Ride ride = rides.Single();

                DateTime endDateUtc = DateTime.UtcNow;
                decimal price = 0.0m;  // TODO: calculate price

                ride.Status = RideStatus.Finished;
                ride.EndDateUtc = endDateUtc;
                ride.TotalAmount = price;

                await repo.UpdateAsync(ride, true);

                return new EndRideResponseDto()
                {
                    Success = true,
                    EndDateUtc = endDateUtc,
                    TotalAmount = price
                };
            }
        }
    }
}
