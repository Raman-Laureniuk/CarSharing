namespace CarSharing.Repository.Entity.DI
{
    using System;
    using CarSharing.Domain.DI;
    using CarSharing.Domain.Repository.Car;
    using CarSharing.Domain.Repository.CarCoordinates;
    using CarSharing.Domain.Repository.Client;
    using CarSharing.Domain.Repository.Ride;
    using CarSharing.Domain.Repository.Tariff;
    using CarSharing.Domain.Repository.Wallet;
    using CarSharing.Repository.Entity.Repository.Car.Impl;
    using CarSharing.Repository.Entity.Repository.CarCoordinates.Impl;
    using CarSharing.Repository.Entity.Repository.Client.Impl;
    using CarSharing.Repository.Entity.Repository.Ride.Impl;
    using CarSharing.Repository.Entity.Repository.Tariff.Impl;
    using CarSharing.Repository.Entity.Repository.Wallet.Impl;

    public static class DIConfig
    {
        public static void RegisterTypes(IDependencyRegister register)
        {
            if (register == null)
            {
                throw new ArgumentNullException(nameof(register));
            }

            RegisterRepositories(register);
        }

        private static void RegisterRepositories(IDependencyRegister register)
        {
            // TODO: RegisterTranient
            register.RegisterScoped<ICarRepository, CarRepository>();
            register.RegisterScoped<ICarCoordinatesRepository, CarCoordinatesRespository>();
            register.RegisterScoped<IClientRepository, ClientRepository>();
            register.RegisterScoped<IRideRepository, RideRepository>();
            register.RegisterScoped<ITariffRepository, TariffRepository>();
            register.RegisterScoped<IWalletRepository, WalletRepository>();
        }
    }
}
