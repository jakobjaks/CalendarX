using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.DAL.Base.Repositories
{
    #region Async and non-async methods together - full set of methods

    public interface IBaseRepository<TDALEntity> : IBaseRepositoryAsync<TDALEntity>, IBaseRepositorySynchronous<TDALEntity>
        where TDALEntity : class, new()
    {
    }

 

    #endregion

    #region Async and common methods

    public interface IBaseRepositoryAsync<TDALEntity> :  IBaseRepositoryCommon<TDALEntity>
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllAsync();
        Task<TDALEntity> FindAsync(params object[] id);
        Task<TDALEntity>  AddAsync(TDALEntity entity);
    }



    #endregion

    #region Only common and non-async method repos

    public interface IBaseRepositorySynchronous<TDALEntity> : IBaseRepositoryCommon<TDALEntity>
        where TDALEntity : class, new()
    {
        List<TDALEntity> All();
        TDALEntity Find(params object[] id);
        TDALEntity Add(TDALEntity entity);
    }


    #endregion

    #region Common methods for all repos

    public interface IBaseRepositoryCommon<TDALEntity>
        where TDALEntity : class,  new()
    {
        TDALEntity Update(TDALEntity entity);
        void Remove(TDALEntity entity);
        void Remove(params object[] id);

        TDALEntity GetUpdatesAfterUOWSaveChanges(TDALEntity entity);
    }

    #endregion
}