namespace CarSharing.Domain.DI.Config
{
    using System;

    public static class DIConfig
    {
        public static void RegisterTypes(IDependencyRegister register)
        {
            if (register == null)
            {
                throw new ArgumentNullException(nameof(register));
            }

            ServicesConfig.RegisterServices(register);
            CommandsConfig.RegisterCommands(register);
            RepositoryFactoryConfig.RegisterRepositoryFactories(register);
        }
    }
}
