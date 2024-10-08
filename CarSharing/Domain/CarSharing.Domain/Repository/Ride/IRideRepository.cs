﻿namespace CarSharing.Domain.Repository.Ride
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Enums.Ride;
    using CarSharing.Domain.Repository.Base;

    public interface IRideRepository : IRepository<Ride>
    {
        Task<List<Ride>> GetRidesForCarAsync(Guid carId, RideStatus status);
        Task<List<Ride>> GetRidesForClientAsync(Guid clientId, params Expression<Func<Ride, object>>[] include);
    }
}
