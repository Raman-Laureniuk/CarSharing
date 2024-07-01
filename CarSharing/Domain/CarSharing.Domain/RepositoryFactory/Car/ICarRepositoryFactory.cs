namespace CarSharing.Domain.RepositoryFactory.Car
{
    using CarSharing.Domain.Repository.Car;
    using CarSharing.Domain.RepositoryFactory.Base;

    public interface ICarRepositoryFactory : IRepositoryFactory<ICarRepository>
    {
    }
}
