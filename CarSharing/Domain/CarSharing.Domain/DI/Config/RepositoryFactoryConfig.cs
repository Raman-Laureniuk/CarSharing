namespace CarSharing.Domain.DI.Config
{
    using CarSharing.Domain.RepositoryFactory.Car;
    using CarSharing.Domain.RepositoryFactory.Car.Impl;
    using CarSharing.Domain.RepositoryFactory.CarCoordinates;
    using CarSharing.Domain.RepositoryFactory.CarCoordinates.Impl;
    using CarSharing.Domain.RepositoryFactory.Client;
    using CarSharing.Domain.RepositoryFactory.Client.Impl;
    using CarSharing.Domain.RepositoryFactory.Ride;
    using CarSharing.Domain.RepositoryFactory.Ride.Impl;
    using CarSharing.Domain.RepositoryFactory.Tariff;
    using CarSharing.Domain.RepositoryFactory.Tariff.Impl;
    using CarSharing.Domain.RepositoryFactory.Wallet;
    using CarSharing.Domain.RepositoryFactory.Wallet.Impl;

    internal class RepositoryFactoryConfig
    {
        public static void RegisterRepositoryFactories(IDependencyRegister register)
        {
            register.RegisterScoped<ICarRepositoryFactory, CarRepositoryFactory>();
            register.RegisterScoped<ICarCoordinatesRepositoryFactory, CarCoordinatesRepositoryFactory>();
            register.RegisterScoped<IClientRepositoryFactory, ClientRepositoryFactory>();
            register.RegisterScoped<IRideRepositoryFactory, RideRepositoryFactory>();
            register.RegisterScoped<ITariffRepositoryFactory, TariffRepositoryFactory>();
            register.RegisterScoped<IWalletRepositoryFactory, WalletRepositoryFactory>();
        }
    }
}
