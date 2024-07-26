namespace CarSharing.Repository.Entity.Repository.Car.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Enums.Ride;
    using CarSharing.Domain.Repository.Car;
    using CarSharing.Repository.Entity.Repository.Base.Impl;
    using Microsoft.EntityFrameworkCore;

    internal class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(IDbContextFactory<CarSharingContext> dbContextFactory)
            : base(dbContextFactory)
        {
        }

        public Task<List<Car>> GetAsync<TSortKey>(bool? isAvailable,
            Expression<Func<Car, TSortKey>> sortKeySelector,
            bool sortAscending,
            int offset,
            int limit,
            params Expression<Func<Car, object>>[] includeKeys)
        {
            IQueryable<Car> cars = GetAllImpl();

            if (isAvailable == true)
            {
                cars = cars.Where(x => x.Rides == null || !x.Rides.Any(r => r.Status == RideStatus.Active));
            }

            if (isAvailable == false)
            {
                cars = cars.Where(x => x.Rides != null || x.Rides.Any(r => r.Status == RideStatus.Active));
            }

            cars = OffsetLimitImpl(cars, sortKeySelector, sortAscending, offset, limit);
            cars = IncludeImpl(cars, includeKeys);

            return cars
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
