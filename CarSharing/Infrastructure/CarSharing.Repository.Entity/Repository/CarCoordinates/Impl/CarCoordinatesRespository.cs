namespace CarSharing.Repository.Entity.Repository.CarCoordinates.Impl
{
    using System;
    using System.Threading.Tasks;
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

        public async Task UpsertAsync(CarCoordinates item, bool commit = false)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            CarCoordinates existingItem = await _context.Set<CarCoordinates>().FindAsync(item.CarId).ConfigureAwait(false);

            if (existingItem == null)
            {
                _context.Set<CarCoordinates>().Add(item);
            }
            else
            {
                _context.Set<CarCoordinates>().Entry(existingItem).State = EntityState.Detached;
                _context.Set<CarCoordinates>().Update(item);
            }

            if (commit)
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
