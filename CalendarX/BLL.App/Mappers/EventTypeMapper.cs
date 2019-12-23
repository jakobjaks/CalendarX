using System;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class EventTypeMapper  : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.EventType))
            {
                return MapFromDAL((internalDTO.EventType) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.EventType))
            {
                return MapFromBLL((externalDTO.EventType) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.EventType MapFromDAL(internalDTO.EventType eventType)
        {
            var res = eventType == null ? null : new externalDTO.EventType()
            {
                Id = eventType.Id,
                Name = eventType.Name,
                Description = eventType.Description,   
                AppUserId = eventType.AppUserId,
            };

            return res;
        }
        
        public static internalDTO.EventType MapFromBLL(externalDTO.EventType eventType)
        {
            var res = eventType == null ? null : new internalDTO.EventType()
            {
                Id = eventType.Id,
                Name = eventType.Name,
                Description = eventType.Description,     
                AppUserId = eventType.AppUserId,
            };

            return res;
        }

    }
}