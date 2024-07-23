namespace CarSharing.Domain.RepositoryFactory.Car.Impl
{
    using CarSharing.Domain.DI;
    using CarSharing.Domain.Repository.Car;
    using CarSharing.Domain.RepositoryFactory.Base.Impl;
    using CarSharing.Domain.RepositoryFactory.Car;

    public class CarRepositoryFactory : RepositoryFactory<ICarRepository>, ICarRepositoryFactory
    {
        public CarRepositoryFactory(IDependencyResolver resolver)
            : base(resolver)
        {
        }
    }
}
