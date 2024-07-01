namespace CarSharing.Domain.RepositoryFactory.Base
{
    public interface IRepositoryFactory<TRepository>
    {
        TRepository CreateRepository();
    }
}
