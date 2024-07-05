namespace CarSharing.Domain.Repository.Ride
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Enums.Ride;
    using CarSharing.Domain.Repository.Base;

    public interface IRideRepository : IRepository<Ride>
    {
        Task<List<Ride>> GetRidesAsync(Guid carId, RideStatus status);
    }
}
