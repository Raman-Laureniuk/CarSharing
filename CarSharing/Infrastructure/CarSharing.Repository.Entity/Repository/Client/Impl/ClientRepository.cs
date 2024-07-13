namespace CarSharing.Repository.Entity.Repository.Client.Impl
{
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Providers.Config;
    using CarSharing.Domain.Repository.Client;
    using CarSharing.Repository.Entity.Repository.Base.Impl;

    internal class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(IConfigProvider configProvider)
            : base(configProvider)
        {
        }
    }
}
