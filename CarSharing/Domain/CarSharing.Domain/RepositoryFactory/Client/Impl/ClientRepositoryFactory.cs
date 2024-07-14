namespace CarSharing.Domain.RepositoryFactory.Client.Impl
{
    using CarSharing.Domain.DI;
    using CarSharing.Domain.Repository.Client;
    using CarSharing.Domain.RepositoryFactory.Base.Impl;

    public class ClientRepositoryFactory : RepositoryFactory<IClientRepository>, IClientRepositoryFactory
    {
        public ClientRepositoryFactory(IResolver resolver)
            : base(resolver)
        {
        }
    }
}
