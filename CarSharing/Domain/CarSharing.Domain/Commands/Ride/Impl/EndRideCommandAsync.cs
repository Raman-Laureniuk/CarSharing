namespace CarSharing.Domain.Commands.Ride.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Ride;
    using CarSharing.Domain.Commands.Tariff;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Dto.Tariff;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Dto.Tariff.Response;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Enums.Ride;
    using CarSharing.Domain.Mappers.Tariff;
    using CarSharing.Domain.Repository.Ride;
    using CarSharing.Domain.RepositoryFactory.Ride;

    internal class EndRideCommandAsync : IEndRideCommandAsync
    {
        private readonly ICalculatePriceCommand _calculatePriceCommand;
        private readonly IRideRepositoryFactory _repoFactory;

        public EndRideCommandAsync(ICalculatePriceCommand calculatePriceCommand,
            IRideRepositoryFactory repoFactory)
        {
            _calculatePriceCommand = calculatePriceCommand ?? throw new ArgumentNullException(nameof(calculatePriceCommand));
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
                List<Ride> rides = await repo.GetRidesForCarAndClientAsync(request.CarId, request.ClientId, RideStatus.Active);  // TODO: Include car with tariff
                Ride ride = rides.Single();

                ride.Status = RideStatus.Finished;
                ride.EndDateUtc = DateTime.UtcNow;
                ride.TotalAmount = GetPrice(ride);

                await repo.UpdateAsync(ride, true);

                return new EndRideResponseDto()
                {
                    Success = true,
                    EndDateUtc = ride.EndDateUtc.Value,
                    TotalAmount = ride.TotalAmount.Value
                };
            }
        }

        private decimal GetPrice(Ride ride)
        {
            if (ride == null)
            {
                throw new ArgumentNullException(nameof(ride));
            }

            if (ride.EndDateUtc == null)
            {
                throw new ArgumentNullException(nameof(ride.EndDateUtc));
            }

            if (ride.Car == null)
            {
                throw new ArgumentNullException(nameof(ride.Car));
            }

            if (ride.Car.Tariff == null)
            {
                throw new ArgumentNullException(nameof(ride.Car.Tariff));
            }

            TimeSpan ridePeriod = ride.EndDateUtc.Value - ride.StartDateUtc;
            TariffDto tariff = ride.Car.Tariff.ToTariffDto();

            CalculatePriceRequestDto request = new CalculatePriceRequestDto()
            {
                Tariff = tariff,
                RidePeriod = ridePeriod
            };

            CalculatePriceResponseDto response = _calculatePriceCommand.Execute(request);

            return response.Price;
        }
    }
}
