namespace CarSharing.Domain.RepositoryFactory.Client
{
    using CarSharing.Domain.Repository.Client;
    using CarSharing.Domain.RepositoryFactory.Base;

    public interface IClientRepositoryFactory : IRepositoryFactory<IClientRepository>
    {
    }
}
