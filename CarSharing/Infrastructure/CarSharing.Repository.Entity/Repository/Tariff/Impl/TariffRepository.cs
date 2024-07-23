namespace CarSharing.Repository.Entity.Repository.Tariff.Impl
{
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Tariff;
    using CarSharing.Repository.Entity.Repository.Base.Impl;
    using Microsoft.EntityFrameworkCore;

    internal class TariffRepository : Repository<Tariff>, ITariffRepository
    {
        public TariffRepository(IDbContextFactory<CarSharingContext> dbContextFactory)
            : base(dbContextFactory)
        {
        }
    }
}
