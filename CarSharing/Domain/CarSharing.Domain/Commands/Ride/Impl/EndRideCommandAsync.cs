﻿namespace CarSharing.Domain.Commands.Ride.Impl
{
    using System;
    using System.Threading.Tasks;
    using CarSharing.Domain.Commands.Ride;
    using CarSharing.Domain.Commands.Tariff;
    using CarSharing.Domain.Dto.Payment.Request;
    using CarSharing.Domain.Dto.Payment.Response;
    using CarSharing.Domain.Dto.Ride.Request;
    using CarSharing.Domain.Dto.Ride.Response;
    using CarSharing.Domain.Dto.Tariff;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Enums.Ride;
    using CarSharing.Domain.Exceptions.Ride;
    using CarSharing.Domain.Mappers.Tariff;
    using CarSharing.Domain.Providers.Payment;
    using CarSharing.Domain.Repository.Ride;
    using CarSharing.Domain.RepositoryFactory.Ride;

    internal class EndRideCommandAsync : IEndRideCommandAsync
    {
        private readonly ICalculatePriceCommand _calculatePriceCommand;
        private readonly IRideRepositoryFactory _repoFactory;
        private readonly IPaymentProvider _paymentProvider;

        public EndRideCommandAsync(ICalculatePriceCommand calculatePriceCommand,
            IRideRepositoryFactory repoFactory,
            IPaymentProvider paymentProvider)
        {
            _calculatePriceCommand = calculatePriceCommand ?? throw new ArgumentNullException(nameof(calculatePriceCommand));
            _repoFactory = repoFactory ?? throw new ArgumentNullException(nameof(repoFactory));
            _paymentProvider = paymentProvider ?? throw new ArgumentNullException(nameof(paymentProvider));
        }

        public async Task<EndRideResponseDto> ExecuteAsync(EndRideRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Ride ride = await GetRideAsync(request.RideId);
            CheckRide(ride, request.ClientId);

            DateTime endDateUtc = DateTime.UtcNow;
            decimal price = GetPrice(ride.Car.Tariff.ToTariffDto(), endDateUtc - ride.StartDateUtc);

            string authorizeToken = await AuthorizePaymentAsync(price, ride.Wallet.EncryptedWalletData);

            try
            {
                await UpdateRideAsync(ride, endDateUtc, price);
            }
            catch (Exception)
            {
                await CancelPaymentAsync(authorizeToken);

                throw;
            }

            await FinalizePaymentAsync(authorizeToken, price);

            return new EndRideResponseDto()
            {
                Success = true,
                EndDateUtc = endDateUtc,
                TotalAmount = price
            };
        }

        private async Task<Ride> GetRideAsync(int rideId)
        {
            using (IRideRepository repo = _repoFactory.CreateRepository())
            {
                return await repo.GetByIdAsync(rideId, "Car.Tariff", "Wallet");
            }
        }

        private async Task UpdateRideAsync(Ride ride, DateTime endDateUtc, decimal totalAmount)
        {
            ride.Status = RideStatus.Finished;
            ride.EndDateUtc = endDateUtc;
            ride.TotalAmount = totalAmount;

            using (IRideRepository repo = _repoFactory.CreateRepository())
            {
                await repo.UpdateAsync(ride, true);
            }
        }

        private void CheckRide(Ride ride, Guid clientId)
        {
            if (ride == null)
            {
                throw new ArgumentNullException(nameof(ride));
            }

            if (ride.Car == null)
            {
                throw new ArgumentNullException(nameof(ride.Car));
            }

            if (ride.Car.Tariff == null)
            {
                throw new ArgumentNullException(nameof(ride.Car.Tariff));
            }

            if (ride.Wallet == null)
            {
                throw new ArgumentNullException(nameof(ride.Wallet));
            }

            if (ride.ClientId != clientId)
            {
                throw new ArgumentException($"Ride {ride.Id} doesn't belong to client {clientId}.");
            }

            if (ride.Status != RideStatus.Active)
            {
                throw new WrongStatusException($"Ride {ride.Id} has wrong status {ride.Status}.");
            }
        }

        private decimal GetPrice(TariffDto tariff, TimeSpan period)
        {
            return _calculatePriceCommand.Execute(new CalculatePriceRequestDto()
            {
                RidePeriod = period,
                Tariff = tariff
            }).Price;
        }

        private async Task<string> AuthorizePaymentAsync(decimal authorizeAmount, string encryptedWalletData)
        {
            AuthorizeResponseDto response = await _paymentProvider.AuthorizeAsync(new AuthorizeRequestDto()
            {
                AuthorizeAmount = authorizeAmount,
                EncryptedWalletData = encryptedWalletData
            });

            return response.AuthorizeToken;
        }

        private Task FinalizePaymentAsync(string authorizeToken, decimal finalizeAmount)
        {
            return _paymentProvider.FinalizeAsync(new FinalizeRequestDto()
            {
                AuthorizeToken = authorizeToken,
                FinalizeAmount = finalizeAmount
            });
        }

        private Task CancelPaymentAsync(string authorizeToken)
        {
            return _paymentProvider.CancelAsync(new CancelRequestDto()
            {
                AuthorizeToken = authorizeToken
            });
        }
    }
}
