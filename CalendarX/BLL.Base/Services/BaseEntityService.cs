using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.Base.Mappers;
using Contracts.BLL.Base.Services;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;

namespace BLL.Base.Services
{
    // ABSTRACT - since we dont want to add generic domain entity here, so no direct instances from this class
    public abstract class BaseEntityService<TBLLEntity, TDALEntity, TUnitOfWork> : BaseService, IBaseEntityService<TBLLEntity> 
        where TBLLEntity : class,  new()
        where TDALEntity : class,  new()
    where TUnitOfWork: IBaseUnitOfWork
    {
        protected readonly TUnitOfWork Uow;
        protected IBaseRepository<TDALEntity> ServiceRepository; 
        private readonly IBaseBLLMapper _mapper;

        public BaseEntityService(TUnitOfWork uow, IBaseBLLMapper mapper)
        {
            Uow = uow;
            _mapper = mapper;
            //_repo = Uow.BaseRepository<TDALEntity>();
        }

        public virtual TBLLEntity Update(TBLLEntity entity)
        {
            return _mapper.Map<TBLLEntity>(ServiceRepository.Update(_mapper.Map<TDALEntity>(entity)));
        }

        public virtual void Remove(TBLLEntity entity)
        {
            ServiceRepository.Remove(_mapper.Map<TDALEntity>(entity));
        }

        public virtual void Remove(params object[] id)
        {
            ServiceRepository.Remove(id);
        }

        public TBLLEntity GetUpdatesAfterUOWSaveChanges(TBLLEntity entity)
        {
            return _mapper.Map<TBLLEntity>(ServiceRepository.GetUpdatesAfterUOWSaveChanges(_mapper.Map<TDALEntity>(entity)));

        }

        public virtual async Task<List<TBLLEntity>> AllAsync()
        {
            return (await ServiceRepository.AllAsync()).Select(e => _mapper.Map<TBLLEntity>(e)).ToList();
        }

        public virtual async Task<TBLLEntity> FindAsync(params object[] id)
        {
            return _mapper.Map<TBLLEntity>(await ServiceRepository.FindAsync(id));
        }

        public virtual async Task<TBLLEntity> AddAsync(TBLLEntity entity)
        {
            return  _mapper.Map<TBLLEntity>(await ServiceRepository.AddAsync(_mapper.Map<TDALEntity>(entity)));
        }

        public List<TBLLEntity> All()
        {
            return ServiceRepository.All().Select(e => _mapper.Map<TBLLEntity>(e)).ToList();
        }

        public TBLLEntity Find(params object[] id)
        {
            return _mapper.Map<TBLLEntity>(ServiceRepository.Find(id));
        }

        public TBLLEntity Add(TBLLEntity entity)
        {
            return _mapper.Map<TBLLEntity>(ServiceRepository.Add(_mapper.Map<TDALEntity>(entity)));
        }
    }
}
