﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrelloManagementSystem.Common.Database.Context;
using TrelloManagementSystem.Models;

namespace TrelloManagementSystem.Features.Common
{
    public class GenericRepository<T>:IDisposable where T : BaseModel
    {
        private readonly TrelloContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(TrelloContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task DeleteAsync(T item)
        {

            item.IsDeleted = true;
            await UpdateInclude(item, nameof(BaseModel.IsDeleted));
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(_dbSet.AsNoTracking().AsEnumerable().Where(X => X.IsDeleted is false));
        }

        public async Task<IQueryable<T>> GetAllWithSpecAsync(Expression<Func<T, bool>> criteria)
        {
            return await Task.FromResult(_dbSet.AsNoTracking().Where(criteria));
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Task.FromResult(_dbSet.FirstOrDefault(x => x.Id == id));
        }

        public async Task<T> GetBySpecAsync(Expression<Func<T, bool>> criteria)
        {
            return await Task.FromResult(_dbSet.AsNoTracking().FirstOrDefault(criteria));
        }

        public async Task UpdateInclude(T entity, params string[] modifiedProperties)
        {
            var local = _dbContext.Set<T>().Local.FirstOrDefault(x => x.Id == entity.Id);
            EntityEntry entityEntry;
            if (local is null)
                entityEntry = _dbContext.Entry(entity);

            else
                entityEntry = _dbContext.ChangeTracker.Entries<T>().FirstOrDefault(X => X.Entity.Id == entity.Id)!;

            foreach (var property in entityEntry.Properties)
            {
                if (modifiedProperties.Contains(property.Metadata.Name))
                {
                    foreach (var propertyEntry in entityEntry.Properties)
                    {
                        var propertyInfo = entity.GetType().GetProperty(property.Metadata.Name);
                        if (propertyInfo != null)
                        {
                            property.CurrentValue = propertyInfo.GetValue(entity);
                            property.IsModified = true;
                        }
                    }

                }
            }
            entityEntry.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();


        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbContext.AddRangeAsync(entities);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbContext.RemoveRange(entities);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null!, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null && includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
