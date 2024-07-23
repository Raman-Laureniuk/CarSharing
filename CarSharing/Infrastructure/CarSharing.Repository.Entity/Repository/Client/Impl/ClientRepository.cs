namespace CarSharing.Repository.Entity.Repository.Client.Impl
{
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Client;
    using CarSharing.Repository.Entity.Repository.Base.Impl;
    using Microsoft.EntityFrameworkCore;

    internal class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }
    }
}
