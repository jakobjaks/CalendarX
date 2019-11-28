using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Helpers;
using Contracts.DAL.Base.Mappers;
using Contracts.DAL.Base.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF.Repositories
{
    public class BaseRepository<TDALEntity, TDomainEntity, TDbContext> :
        BaseRepository<TDALEntity, TDomainEntity, TDbContext, int>
        where TDALEntity : class, new()
        where TDomainEntity : class, IDomainEntity, new()
        where TDbContext : DbContext
    {
        public BaseRepository(TDbContext repositoryDbContext, IBaseDALMapper mapper) : base(repositoryDbContext, mapper)
        {
        }
    }


    public class BaseRepository<TDALEntity, TDomainEntity, TDbContext, TKey> : IBaseRepository<TDALEntity>
        where TDALEntity : class, new()
        where TDomainEntity : class, IDomainEntity<TKey>, new()
        where TDbContext : DbContext
        where TKey : IComparable
    {
        protected readonly TDbContext RepositoryDbContext;
        protected readonly DbSet<TDomainEntity> RepositoryDbSet;

        private readonly IBaseDALMapper _mapper;

        
        protected readonly IDictionary<TKey, TDomainEntity> EntityCreationCache = new Dictionary<TKey, TDomainEntity>();

        
        public BaseRepository(TDbContext repositoryDbContext, IBaseDALMapper mapper)
        {
            RepositoryDbContext = repositoryDbContext;
            _mapper = mapper;
            // get the dbset by type from db context
            RepositoryDbSet = RepositoryDbContext.Set<TDomainEntity>();
        }


        public virtual TDALEntity Update(TDALEntity entity)
        {
            return _mapper.Map<TDALEntity>(RepositoryDbSet.Update(_mapper.Map<TDomainEntity>(entity)).Entity);
        }

        public virtual void Remove(TDALEntity entity)
        {
            RepositoryDbSet.Remove(_mapper.Map<TDomainEntity>(entity));
        }

        public virtual void Remove(params object[] id)
        {
            RepositoryDbSet.Remove(RepositoryDbSet.Find(id));
        }

        public TDALEntity GetUpdatesAfterUOWSaveChanges(TDALEntity entity)
        {
            var domainEntity = _mapper.Map<TDomainEntity>(entity);
            return EntityCreationCache.ContainsKey(domainEntity.Id) ? _mapper.Map<TDALEntity>(EntityCreationCache[domainEntity.Id]) : entity;
        }

        public virtual async Task<List<TDALEntity>> AllAsync()
        {
            return (await RepositoryDbSet.ToListAsync())
                .Select(e => _mapper.Map<TDALEntity>(e)).ToList();
        }

        public virtual async Task<TDALEntity> FindAsync(params object[] id)
        {
            return _mapper.Map<TDALEntity>( (await RepositoryDbSet.FindAsync(id)));
        }

        public virtual async Task<TDALEntity> AddAsync(TDALEntity entity)
        {
            //EntityCreationCache
            var res = (await RepositoryDbSet.AddAsync(_mapper.Map<TDomainEntity>(entity))).Entity;
            EntityCreationCache.Add(res.Id, res); 
            return _mapper.Map<TDALEntity>(res);
        }

        public List<TDALEntity> All()
        {
            return RepositoryDbSet.Select(e => _mapper.Map<TDALEntity>(e)).ToList();
        }

        public TDALEntity Find(params object[] id)
        {
            return _mapper.Map<TDALEntity>(RepositoryDbSet.Find(id));
        }

        public TDALEntity Add(TDALEntity entity)
        {
            return _mapper.Map<TDALEntity>(RepositoryDbSet.Add(_mapper.Map<TDomainEntity>(entity)).Entity);
        }
        
        public ICollection<int> ToIdCollection(List<IDomainEntity> entities)
        {
            var list = new List<int>();
            foreach (var entity in entities)
            {
                list.Add(entity.Id);
            }
            return list;
        }
    }
}
