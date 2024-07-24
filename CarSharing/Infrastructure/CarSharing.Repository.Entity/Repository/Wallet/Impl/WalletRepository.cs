namespace CarSharing.Repository.Entity.Repository.Wallet.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Wallet;
    using CarSharing.Repository.Entity.Repository.Base.Impl;
    using Microsoft.EntityFrameworkCore;

    internal class WalletRepository : Repository<Wallet>, IWalletRepository
    {
        public WalletRepository(IDbContextFactory<CarSharingContext> dbContextFactory)
            : base(dbContextFactory)
        {
        }

        public Task<List<Wallet>> GetWalletsForClient(Guid clientId)
        {
            return _context
                .Set<Wallet>()
                .Where(x => x.ClientId == clientId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
