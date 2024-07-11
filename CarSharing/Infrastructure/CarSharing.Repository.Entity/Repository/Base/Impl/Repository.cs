﻿namespace CarSharing.Repository.Entity.Repository.Base.Impl
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarSharing.Domain.Providers.Config;
    using CarSharing.Domain.Repository.Base;
    using CarSharing.Domain.Tools.Extensions;
    using Microsoft.EntityFrameworkCore;

    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly CarSharingContext _context;

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
            return _context
                .Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id, params string[] include)
        {
            T item = await _context
                .Set<T>()
                .FindAsync(id);

            if (item == null)
            {
                return item;
            }

            foreach (string s in include.OrEmptyIfNull())
            {
                await _context.Entry(item).Reference(s).LoadAsync();
            }

            _context.Entry(item).State = EntityState.Detached;

            return item;
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