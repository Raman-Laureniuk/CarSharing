namespace CarSharing.WebApi.Common.DI.Impl
{
    using System;
    using CarSharing.Domain.DI;
    using Microsoft.Extensions.DependencyInjection;

    internal class DependencyResolverServiceProviderAdapter : IDependencyResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public DependencyResolverServiceProviderAdapter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public T Resolve<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
