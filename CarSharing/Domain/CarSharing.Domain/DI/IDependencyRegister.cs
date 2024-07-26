namespace CarSharing.Domain.DI
{
    using System;

    public interface IDependencyRegister
    {
        void RegisterScoped<TService>()
            where TService : class;
        
        void RegisterScoped<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;

        void RegisterScoped<TService>(Func<IDependencyResolver, TService> implementationFactory)
            where TService : class;

        void RegisterTransient<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;
    }
}
