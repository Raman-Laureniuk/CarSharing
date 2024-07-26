namespace CarSharing.Domain.Repository.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<T> : IDisposable
    {
        Task CreateAsync(T item, bool commit = false);
        Task UpdateAsync(T item, bool commit = false);
        Task DeleteAsync(object id, bool commit = false);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAsync<TSortKey>(Expression<Func<T, TSortKey>> sortKeySelector, bool sortAscending, int offset, int limit);
        Task<T> GetByIdAsync(object id);
        Task<T> GetByIdAsync(object id, params Expression<Func<T, object>>[] include);

        Task CommitAsync();
    }
}
