using System;

namespace Contracts.DAL.Base
{
    public interface IBaseEntity : IBaseEntity<int>
    {
    }

    public interface IBaseEntity<TKey> where TKey : IComparable
    {
        TKey Id { get; set; }
    }
}