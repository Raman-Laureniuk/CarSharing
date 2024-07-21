namespace CarSharing.Repository.Entity.Repository.Base.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using CarSharing.Domain.Providers.Config;
    using CarSharing.Domain.Repository.Base;
    using CarSharing.Domain.Tools.Extensions;
    using Microsoft.EntityFrameworkCore;

    internal class Repository<T> : IRepository<T>
        where T : class
    {
        protected readonly CarSharingContext _context;

        public Repository(IConfigProvider configProvider)
        {
            _context = new CarSharingContext(configProvider);
        }
        
        public Task CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task CreateAsync(T item, bool commit = false)
        {
            _context.Set<T>().Add(item);

            if (commit)
            {
                return _context.SaveChangesAsync();
            }

            return Task.CompletedTask;
        }

        public async Task DeleteAsync(object id, bool commit = false)
        {
            T item = await _context.Set<T>().FindAsync(id);

            if (item == null)
            {
                return;
            }

            _context.Set<T>().Remove(item);

            if (commit)
            {
                await _context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<List<T>> GetAllAsync()
        {
            return GetAllImpl()
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<List<T>> GetAsync<TSortKey>(Expression<Func<T, TSortKey>> sortKeySelector, bool sortAscending, int offset, int limit)
        {
            IQueryable<T> items = GetAllImpl(sortKeySelector, sortAscending, offset, limit);

            return items
                .AsNoTracking()
                .ToListAsync();
        }

        protected IQueryable<T> GetAllImpl<TSortKey>(Expression<Func<T, TSortKey>> sortKeySelector, bool sortAscending, int offset, int limit)
        {
            IQueryable<T> items = GetAllImpl();

            items = items.Skip(offset).Take(limit);

            return items;
        }
        
        protected IQueryable<T> GetAllImpl<TSortKey>(Expression<Func<T, TSortKey>> sortKeySelector, bool sortAscending)
        {
            IQueryable<T> items = GetAllImpl();

            items = sortAscending ? items.OrderBy(sortKeySelector) : items.OrderByDescending(sortKeySelector);

            return items;
        }

        protected IQueryable<T> GetAllImpl()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            T item = await GetByIdAsyncImpl(id);

            if (item == null)
            {
                return item;
            }

            _context.Entry(item).State = EntityState.Detached;

            return item;
        }
        
        public async Task<T> GetByIdAsync(object id, params Expression<Func<T, object>>[] include)
        {
            T item = await GetByIdAsyncImpl(id);

            if (item == null)
            {
                return item;
            }

            foreach (Expression<Func<T, object>> i in include.OrEmptyIfNull())
            {
                await _context.Entry(item).Reference(i).LoadAsync();
            }

            _context.Entry(item).State = EntityState.Detached;

            return item;
        }

        protected ValueTask<T> GetByIdAsyncImpl(object id)
        {
            return _context
                .Set<T>()
                .FindAsync(id);
        }

        public Task UpdateAsync(T item, bool commit = false)
        {
            _context.Set<T>().Attach(item);
            _context.Entry(item).State = EntityState.Modified;

            if (commit)
            {
                return _context.SaveChangesAsync();
            }

            return Task.CompletedTask;
        }

        public Task UpsertAsync(T item, bool commit = false)
        {
            _context.Set<T>().Update(item);

            if (commit)
            {
                return _context.SaveChangesAsync();
            }

            return Task.CompletedTask;
        }
    }
}
