namespace CarSharing.Domain.Commands.Ride.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Ride;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Mappers.Ride.Response;
    using CarSharing.Domain.Repository.Ride;
    using CarSharing.Domain.RepositoryFactory.Ride;

    internal class GetRideHistoryCommandAsync : IGetRideHistoryCommandAsync
    {
        private readonly IRideRepositoryFactory _repoFactory;

        public GetRideHistoryCommandAsync(IRideRepositoryFactory repoFactory)
        {
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
        }

        public async Task<GetRideHistoryResponseDto> ExecuteAsync(GetRideHistoryRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using (IRideRepository repo = _repoFactory.CreateRepository())
            {
                List<Ride> rides = await repo.GetRidesForClientAsync(request.ClientId);

                return rides.ToGetRideHistoryResponseDto();
            }
        }
    }
}
