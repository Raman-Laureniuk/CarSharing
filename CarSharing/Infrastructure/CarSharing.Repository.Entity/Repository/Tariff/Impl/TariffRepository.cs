namespace CarSharing.Repository.Entity.Repository.Tariff.Impl
{
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Providers.Config;
    using CarSharing.Domain.Repository.Tariff;
    using CarSharing.Repository.Entity.Repository.Base.Impl;

    internal class TariffRepository : Repository<Tariff>, ITariffRepository
    {
        public TariffRepository(IConfigProvider configProvider)
            : base(configProvider)
        {
        }
    }
}
