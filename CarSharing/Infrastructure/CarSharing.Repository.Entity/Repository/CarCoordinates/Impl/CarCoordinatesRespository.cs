namespace CarSharing.Repository.Entity.Repository.CarCoordinates.Impl
{
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.CarCoordinates;
    using CarSharing.Repository.Entity.Repository.Base.Impl;
    using Microsoft.EntityFrameworkCore;

    internal class CarCoordinatesRespository : Repository<CarCoordinates>, ICarCoordinatesRepository
    {
        public CarCoordinatesRespository(IDbContextFactory<CarSharingContext> dbContextFactory)
            : base(dbContextFactory)
        {
        }
    }
}
