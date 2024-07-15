namespace CarSharing.Repository.Entity.Repository.Car.Impl
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Enums.Ride;
    using CarSharing.Domain.Providers.Config;
    using CarSharing.Domain.Repository.Car;
    using CarSharing.Repository.Entity.Repository.Base.Impl;
    using Microsoft.EntityFrameworkCore;

    internal class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(IConfigProvider configProvider)
            : base(configProvider)
        {
        }

        public Task<List<Car>> GetAsync(bool? isAvailable)
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

            return cars
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
