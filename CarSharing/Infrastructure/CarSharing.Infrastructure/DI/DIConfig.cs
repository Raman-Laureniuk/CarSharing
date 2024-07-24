namespace CarSharing.Infrastructure.DI
{
    using System;
    using CarSharing.Domain.DI;
    using CarSharing.Domain.Providers.CarControl;
    using CarSharing.Domain.Providers.Config;
    using CarSharing.Domain.Providers.Payment;
    using CarSharing.Infrastructure.Providers.CarControl.Impl;
    using CarSharing.Infrastructure.Providers.Config;
    using CarSharing.Infrastructure.Providers.Payment.Impl;

    public static class DIConfig
    {
        public static void RegisterTypes(IDependencyRegister register)
        {
            if (register == null)
            {
                throw new ArgumentNullException(nameof(register));
            }
            
            RegisterProviders(register);
        }

        private static void RegisterProviders(IDependencyRegister register)
        {
            register.RegisterScoped<ICarControlProvider, MockCarControlProvider>();
            register.RegisterScoped<IConfigProvider, ConfigProvider>();
            register.RegisterScoped<IPaymentProvider, MockPaymentProvider>();
        }
    }
}
