namespace CarSharing.WebApi.Common.Adapters
{
    using CarSharing.Domain.DI;
    using CarSharing.WebApi.Common.DI.Impl;
    using Microsoft.Extensions.DependencyInjection;

    internal static class DependencyRegisterAdapter
    {
        public static IDependencyRegister Adapter(this IServiceCollection services)
        {
            return new DependencyRegisterServiceCollectionAdapter(services);
        }
    }
}
