namespace CarSharing.Domain.Repository.Car
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using CarSharing.Domain.Entities;
    using CarSharing.Domain.Repository.Base;

    public interface ICarRepository : IRepository<Car>
    {
        Task<List<Car>> GetAsync<TSortKey>(bool? isAvailable,
            Expression<Func<Car, TSortKey>> sortKeySelector,
            bool sortAscending,
            int offset,
            int limit,
            params Expression<Func<Car, object>>[] includeKeys);
    }
}
