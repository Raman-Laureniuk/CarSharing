namespace CarSharing.Domain.RepositoryFactory.CarCoordinates.Impl
{
    using CarSharing.Domain.DI;
    using CarSharing.Domain.Repository.CarCoordinates;
    using CarSharing.Domain.RepositoryFactory.Base.Impl;

    public class CarCoordinatesRepositoryFactory : RepositoryFactory<ICarCoordinatesRepository>, ICarCoordinatesRepositoryFactory
    {
        public CarCoordinatesRepositoryFactory(IResolver resolver)
            : base(resolver)
        {
        }
    }
}
