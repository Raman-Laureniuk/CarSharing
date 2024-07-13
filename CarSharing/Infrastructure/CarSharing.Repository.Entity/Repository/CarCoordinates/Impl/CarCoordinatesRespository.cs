namespace CarSharing.Repository.Entity.Repository.CarCoordinates.Impl
{
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Providers.Config;
    using CarSharing.Domain.Repository.CarCoordinates;
    using CarSharing.Repository.Entity.Repository.Base.Impl;

    internal class CarCoordinatesRespository : Repository<CarCoordinates>, ICarCoordinatesRepository
    {
        public CarCoordinatesRespository(IConfigProvider configProvider)
            : base(configProvider)
        {
        }
    }
}
