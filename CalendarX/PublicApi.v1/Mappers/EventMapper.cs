using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class EventMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Event))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Event) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Event))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.Event) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Event MapFromBLL(internalDTO.Event Event)
        {
            var res = Event == null ? null : new externalDTO.Event
            {
                Id = Event.Id,
                Name = Event.Name,
                Description = Event.Description,   
                AppUserId = Event.AppUserId,
            };

            return res;
        }

        public static internalDTO.Event MapFromExternal(externalDTO.Event Event)
        {
            Console.WriteLine(Event.Name + "BLL");

            var res = Event == null ? null : new internalDTO.Event
            {
                Id = Event.Id,
                Name = Event.Name,
                Description = Event.Description,   
                AppUserId = Event.AppUserId,
            };
            Console.WriteLine(res.Name + "BLL");

            return res;
        }
    }
}