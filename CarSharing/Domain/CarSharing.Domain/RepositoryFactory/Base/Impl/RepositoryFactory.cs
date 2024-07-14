namespace CarSharing.Domain.RepositoryFactory.Base.Impl
{
    using System;
    using CarSharing.Domain.DI;
    using CarSharing.Domain.RepositoryFactory.Base;

    public abstract class RepositoryFactory<TRepository> : IRepositoryFactory<TRepository>
    {
        private readonly IResolver _resolver;

        public RepositoryFactory(IResolver resolver)
        {
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        public TRepository CreateRepository()
        {
            return _resolver.Resolve<TRepository>();
        }
    }
}
