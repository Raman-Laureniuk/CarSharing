namespace CarSharing.WebApi.Common.DI.Impl
{
    using System;
    using CarSharing.Domain.DI;
    using Microsoft.Extensions.DependencyInjection;

    public class DependencyRegisterServiceCollectionAdapter : IDependencyRegister
    {
        private readonly IServiceCollection _serviceCollection;

        public DependencyRegisterServiceCollectionAdapter(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));
        }

        public void RegisterScoped<TService>()
            where TService : class
        {
            _serviceCollection.AddScoped<TService>();
        }

        public void RegisterScoped<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            _serviceCollection.AddScoped<TService, TImplementation>();
        }

        public void RegisterScoped<TService>(Func<IDependencyResolver, TService> implementationFactory)
            where TService: class
        {
            _serviceCollection.AddScoped(serviceProvider => implementationFactory(new DependencyResolverServiceProviderAdapter(serviceProvider)));
        }
    }
}
