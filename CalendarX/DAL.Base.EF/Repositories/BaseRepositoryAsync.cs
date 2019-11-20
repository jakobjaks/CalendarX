using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF.Repositories
{
    public class BaseRepositoryAsync<TEntity> : BaseRepositoryAsync<TEntity, int>
    where TEntity: class, IBaseEntity<int>, new()
    {
        public BaseRepositoryAsync(DbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
    
    public class BaseRepositoryAsync<TEntity, TKey> : IBaseRepositoryAsync<TEntity, TKey>
        where TEntity: class, IBaseEntity<TKey>, new()
        where TKey: IComparable
    {

        protected readonly DbContext RepositoryDbContext;
        protected readonly DbSet<TEntity> RepositoryDbSet;

        public BaseRepositoryAsync(DbContext repositoryDbContext)
        {
            RepositoryDbContext = repositoryDbContext;
            RepositoryDbSet = RepositoryDbContext.Set<TEntity>();        
        }

        public virtual TEntity Update(TEntity entity)
        {
            return RepositoryDbSet.Update(entity).Entity;
        }

        public virtual void Remove(TEntity entity)
        {
            RepositoryDbSet.Remove(entity);
        }

        public virtual void Remove(params object[] id)
        {
            RepositoryDbSet.Remove(FindAsync(id).Result);
        }

        public virtual async Task<IEnumerable<TEntity>> AllAsync()
        {
            return await RepositoryDbSet.ToListAsync();
        }

        public virtual async Task<TEntity> FindAsync(params object[] id)
        {
            return await RepositoryDbSet.FindAsync(id);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await RepositoryDbSet.AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await RepositoryDbContext.SaveChangesAsync();
        }
    }
}