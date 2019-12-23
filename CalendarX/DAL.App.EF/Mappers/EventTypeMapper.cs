using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class EventTypeMapper  : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.EventType))
            {
                return MapFromDomain((internalDTO.EventType) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.EventType))
            {
                return MapFromDAL((externalDTO.EventType) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.EventType MapFromDomain(internalDTO.EventType eventType)
        {
            var res = eventType == null ? null : new externalDTO.EventType()
            {
                Id = eventType.Id,
                Name = eventType.Name,
                Description = eventType.Description,
                
            };

            return res;
        }
        
        public static internalDTO.EventType MapFromDAL(externalDTO.EventType eventType)
        {
            var res = eventType == null ? null : new internalDTO.EventType()
            {
                Id = eventType.Id,
                Name = eventType.Name,
                Description = eventType.Description,
            };

            return res;
        }

    }
}