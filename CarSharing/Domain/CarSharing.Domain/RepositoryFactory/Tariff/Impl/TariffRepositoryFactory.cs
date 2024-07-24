namespace CarSharing.Domain.RepositoryFactory.Tariff.Impl
{
    using CarSharing.Domain.DI;
    using CarSharing.Domain.Repository.Tariff;
    using CarSharing.Domain.RepositoryFactory.Base.Impl;

    public class TariffRepositoryFactory : RepositoryFactory<ITariffRepository>, ITariffRepositoryFactory
    {
        public TariffRepositoryFactory(IDependencyResolver resolver)
            : base(resolver)
        {
        }
    }
}
