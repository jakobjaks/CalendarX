using System;
using Contracts.BLL.Base.Services;

namespace BLL.Base.Services
{
    public class BaseService : IBaseService
    {
        public Guid InstanceId { get; } = Guid.NewGuid();
    }
}