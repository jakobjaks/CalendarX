using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class EventTypeMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.EventType))
            {
                // map internal to external
                return MapFromBLL((internalDTO.EventType) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.EventType))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.EventType) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.EventType MapFromBLL(internalDTO.EventType eventType)
        {
            var res = eventType == null ? null : new externalDTO.EventType
            {
                Id = eventType.Id,
                Name = eventType.Name,
                Description = eventType.Description,   
                AppUserId = eventType.AppUserId,
            };

            return res;
        }

        public static internalDTO.EventType MapFromExternal(externalDTO.EventType eventType)
        {
            Console.WriteLine(eventType.Name + "BLL");

            var res = eventType == null ? null : new internalDTO.EventType
            {
                Id = eventType.Id,
                Name = eventType.Name,
                Description = eventType.Description,   
                AppUserId = eventType.AppUserId,
            };
            Console.WriteLine(res.Name + "BLL");

            return res;
        }
    }
}