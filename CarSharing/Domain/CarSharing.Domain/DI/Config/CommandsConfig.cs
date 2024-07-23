namespace CarSharing.Domain.DI.Config
{
    using CarSharing.Domain.Commands.Car;
    using CarSharing.Domain.Commands.Car.Impl;
    using CarSharing.Domain.Commands.Client;
    using CarSharing.Domain.Commands.Client.Impl;
    using CarSharing.Domain.Commands.Client.Impl.Decorators;
    using CarSharing.Domain.Commands.Coordinates;
    using CarSharing.Domain.Commands.Coordinates.Impl;
    using CarSharing.Domain.Commands.Ride.End;
    using CarSharing.Domain.Commands.Ride.End.Impl;
    using CarSharing.Domain.Commands.Ride.End.Impl.Decorators;
    using CarSharing.Domain.Commands.Ride.GetHistory;
    using CarSharing.Domain.Commands.Ride.GetHistory.Impl;
    using CarSharing.Domain.Commands.Ride.Start;
    using CarSharing.Domain.Commands.Ride.Start.Impl;
    using CarSharing.Domain.Commands.Ride.Start.Impl.Decorators;
    using CarSharing.Domain.Commands.Tariff;
    using CarSharing.Domain.Commands.Tariff.Impl;
    using CarSharing.Domain.Commands.Wallet;
    using CarSharing.Domain.Commands.Wallet.Impl;
    using CarSharing.Domain.Commands.Wallet.Impl.Decoraotrs;
    using CarSharing.Domain.Providers.CarControl;
    using CarSharing.Domain.RepositoryFactory.Client;
    using CarSharing.Domain.RepositoryFactory.Ride;

    internal static class CommandsConfig
    {
        public static void RegisterCommands(IDependencyRegister register)
        {
            RegisterCarCommands(register);
            RegisterClientCommands(register);
            RegisterCoordinatesCommands(register);
            RegisterRideCommands(register);
            RegisterTariffCommands(register);
            RegisterWalletCommands(register);
        }

        private static void RegisterCarCommands(IDependencyRegister register)
        {
            register.RegisterScoped<IAddCarCommandAsync, AddCarCommandAsync>();
            register.RegisterScoped<IDeleteCarCommandAsync, DeleteCarCommandAsync>();
            register.RegisterScoped<IGetCarsCommandAsync, GetCarsCommandAsync>();
            register.RegisterScoped<IUpdateCarCommandAsync, UpdateCarCommandAsync>();
        }

        private static void RegisterClientCommands(IDependencyRegister register)
        {
            register.RegisterScoped<IActivateClientCommandAsync, ActivateClientCommandAsync>();
            register.RegisterScoped<IAddClientCommandAsync, AddClientCommandAsync>();
            register.RegisterScoped<IDeactivateClientCommandAsync, DeactivateClientCommandAsync>();
            register.RegisterScoped<IDeleteClientCommandAsync, DeleteClientCommandAsync>();
            register.RegisterScoped<IGetClientsCommandAsync, GetClientsCommandAsync>();

            register.RegisterScoped<UpdateClientCommandAsync>();
            register.RegisterScoped<IUpdateClientCommandAsync>(factory =>
                new UpdateClientDeactivateDecorator(factory.Resolve<IDeactivateClientCommandAsync>(),
                                                    factory.Resolve<UpdateClientCommandAsync>())
            );
        }

        private static void RegisterCoordinatesCommands(IDependencyRegister register)
        {
            register.RegisterScoped<IAddOrUpdateCoordinatesCommandAsync, AddOrUpdateCoordinatesCommandAsync>();
        }

        private static void RegisterRideCommands(IDependencyRegister register)
        {
            register.RegisterScoped<StartRideCommandAsync>();
            register.RegisterScoped<IStartRideCommandAsync>(factory =>
                new StartRideCarControlDecorator(factory.Resolve<ICarControlProvider>(),
                    new StartRideCarInUseCheckDecorator(factory.Resolve<IRideRepositoryFactory>(),
                        new StartRideClientActiveCheckDecorator(factory.Resolve<IClientRepositoryFactory>(),
                            new StartRideWalletCheckDecorator(factory.Resolve<ICheckWalletForClientCommandAsync>(),
                                factory.Resolve<StartRideCommandAsync>())))));

            register.RegisterScoped<EndRideCommandAsync>();
            register.RegisterScoped<IEndRideCommandAsync>(factory =>
                new EndRideCarControlDecorator(factory.Resolve<IRideRepositoryFactory>(), factory.Resolve<ICarControlProvider>(),
                    new EndRideCheckDecorator(factory.Resolve<IRideRepositoryFactory>(),
                        factory.Resolve<EndRideCommandAsync>())));

            register.RegisterScoped<IGetRideHistoryCommandAsync, GetRideHistoryCommandAsync>();
        }

        private static void RegisterTariffCommands(IDependencyRegister register)
        {
            register.RegisterScoped<IAddTariffCommandAsync, AddTariffCommandAsync>();
            register.RegisterScoped<ICalculatePriceCommand, CalculatePriceCommand>();
            register.RegisterScoped<IDeleteTariffCommandAsync, DeleteTariffCommandAsync>();
            register.RegisterScoped<IGetTariffsCommandAsync, GetTariffsCommandAsync>();
            register.RegisterScoped<IUpdateTariffCommandAsync, UpdateTariffCommandAsync>();
        }

        private static void RegisterWalletCommands(IDependencyRegister register)
        {
            register.RegisterScoped<IAddWalletCommandAsync, AddWalletCommandAsync>();
            register.RegisterScoped<ICheckWalletForClientCommandAsync, CheckWalletForClientCommandAsync>();

            register.RegisterScoped<DeleteWalletCommandAsync>();
            register.RegisterScoped<IDeleteWalletCommandAsync>(factory =>
                new DeleteWalletClientCheckDecorator(factory.Resolve<ICheckWalletForClientCommandAsync>(),
                                                     factory.Resolve<DeleteWalletCommandAsync>()));

            register.RegisterScoped<IGetWalletsCommandAsync, GetWalletsCommandAsync>();
        }
    }
}
