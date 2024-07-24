namespace CarSharing.WebApi.Common.DI
{
    using System;
    using CarSharing.Domain.DI;
    using CarSharing.Repository.Entity.Repository.Base.Impl;
    using CarSharing.WebApi.Common.Adapters;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using DomainConfig = Domain.DI.Config.DIConfig;
    using EntityRepositoryConfig = CarSharing.Repository.Entity.DI.DIConfig;
    using InfrastructureConfig = CarSharing.Infrastructure.DI.DIConfig;

    public static class DIConfig
    {
        public static void RegisterTypes(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.AddDbContextFactory<CarSharingContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CarSharing.Repository.Entity.ConnectionString")));
            
            IDependencyRegister adapter = services.Adapter();

            DomainConfig.RegisterTypes(adapter);
            InfrastructureConfig.RegisterTypes(adapter);
            EntityRepositoryConfig.RegisterTypes(adapter);
        }
    }
}
