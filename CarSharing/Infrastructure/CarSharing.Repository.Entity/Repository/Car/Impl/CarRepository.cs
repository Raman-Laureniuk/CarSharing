namespace CarSharing.Repository.Entity.Repository.Car.Impl
{
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Providers.Config;
    using CarSharing.Domain.Repository.Car;
    using CarSharing.Repository.Entity.Repository.Base.Impl;

    internal class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(IConfigProvider configProvider)
            : base(configProvider)
        {
        }
    }
}
