using System;
using System.Threading.Tasks;
using Contracts.BLL.Base;
using Contracts.BLL.Base.Helpers;
using Contracts.BLL.Base.Services;
using Contracts.DAL.Base;

namespace BLL.Base
{
    public class BaseBLL<TUnitOfWork> : IBaseBLL
        where TUnitOfWork: IBaseUnitOfWork
    {
        public virtual Guid InstanceId { get; } = Guid.NewGuid();


        protected readonly TUnitOfWork UnitOfWork;
        protected readonly IBaseServiceProvider ServiceProvider;

        public BaseBLL(TUnitOfWork unitOfWork, IBaseServiceProvider serviceProvider)
        {
            UnitOfWork = unitOfWork;
            ServiceProvider = serviceProvider;
        }

        /*
        public virtual IBaseEntityService<TEntity> BaseEntityService<TEntity>() where TEntity : class, IDomainEntity, new()
        {
            return ServiceProvider.GetEntityService<TEntity>();
        }
        */

        public virtual async Task<int> SaveChangesAsync()
        {
            return await UnitOfWork.SaveChangesAsync();   
        }

        public int SaveChanges()
        {
            return UnitOfWork.SaveChanges();
        }
    }
}