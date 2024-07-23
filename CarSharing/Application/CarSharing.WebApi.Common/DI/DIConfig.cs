namespace CarSharing.WebApi.Common.DI
{
    using System;
    using CarSharing.Domain.DI;
    using CarSharing.WebApi.Common.Adapters;
    using Microsoft.Extensions.DependencyInjection;
    using DomainConfig = Domain.DI.Config.DIConfig;
    using EntityRepositoryConfig = CarSharing.Repository.Entity.DI.DIConfig;
    using InfrastructureConfig = CarSharing.Infrastructure.DI.DIConfig;

    public static class DIConfig
    {
        public static void RegisterTypes(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            IDependencyRegister adapter = services.Adapter();

            DomainConfig.RegisterTypes(adapter);
            InfrastructureConfig.RegisterTypes(adapter);
            EntityRepositoryConfig.RegisterTypes(adapter);
        }
    }
}
