namespace CarSharing.Domain.DI.Config
{
    using CarSharing.Domain.Services.Car;
    using CarSharing.Domain.Services.Car.Impl;
    using CarSharing.Domain.Services.Client;
    using CarSharing.Domain.Services.Client.Impl;
    using CarSharing.Domain.Services.Coordinates;
    using CarSharing.Domain.Services.Coordinates.Impl;
    using CarSharing.Domain.Services.Ride;
    using CarSharing.Domain.Services.Ride.Impl;
    using CarSharing.Domain.Services.Tariff;
    using CarSharing.Domain.Services.Tariff.Impl;
    using CarSharing.Domain.Services.Wallet;
    using CarSharing.Domain.Services.Wallet.Impl;

    internal static class ServicesConfig
    {
        public static void RegisterServices(IDependencyRegister register)
        {
            register.RegisterScoped<ICarService, CarService>();
            register.RegisterScoped<IClientService, ClientService>();
            register.RegisterScoped<ICoordinatesService, CoordinatesService>();
            register.RegisterScoped<IRideService, RideService>();
            register.RegisterScoped<ITariffService, TariffService>();
            register.RegisterScoped<IWalletService, WalletService>();
        }
    }
}
