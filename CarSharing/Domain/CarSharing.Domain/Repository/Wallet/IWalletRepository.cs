namespace CarSharing.Domain.Repository.Wallet
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Base;

    public interface IWalletRepository : IRepository<Wallet>
    {
        Task<List<Wallet>> GetWalletsForClient(Guid clientId);
    }
}
