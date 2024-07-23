namespace CarSharing.Repository.Entity.Repository.Ride.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Enums.Ride;
    using CarSharing.Domain.Repository.Ride;
    using CarSharing.Repository.Entity.Repository.Base.Impl;
    using Microsoft.EntityFrameworkCore;

    internal class RideRepository : Repository<Ride>, IRideRepository
    {
        public RideRepository(IDbContextFactory<CarSharingContext> dbContextFactory)
            : base(dbContextFactory)
        {
        }

        public Task<List<Ride>> GetRidesForCarAsync(Guid carId, RideStatus status)
        {
            return _context
                .Set<Ride>()
                .Where(x => x.CarId == carId && x.Status == status)
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<List<Ride>> GetRidesForClientAsync(Guid clientId)
        {
            return _context
                .Set<Ride>()
                .Where(x => x.ClientId == clientId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
