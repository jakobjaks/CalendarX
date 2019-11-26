using System;

namespace Contracts.DAL.Base
{
    public interface IDomainEntity: IDomainEntity<int>
    {
       
    }

    public interface IDomainEntity<TKey> where TKey: IComparable
    {
        TKey Id { get; set;}
    }
    
}