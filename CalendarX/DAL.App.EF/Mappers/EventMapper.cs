using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class EventMapper  : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Event))
            {
                return MapFromDomain((internalDTO.Event) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Event))
            {
                return MapFromDAL((externalDTO.Event) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Event MapFromDomain(internalDTO.Event Event)
        {
            var res = Event == null ? null : new externalDTO.Event()
            {
                Id = Event.Id,
                Name = Event.Name,
                Description = Event.Description,   
                NextEventId = Event.NextEventId,
                SubEventId = Event.SubEventId,
                AppUserId = Event.AppUserId,
            };

            return res;
        }
        
        public static internalDTO.Event MapFromDAL(externalDTO.Event Event)
        {
            var res = Event == null ? null : new internalDTO.Event()
            {
                Id = Event.Id,
                Name = Event.Name,
                Description = Event.Description,   
                NextEventId = Event.NextEventId,
                SubEventId = Event.SubEventId,
                AppUserId = Event.AppUserId,
            };

            return res;
        }

    }
}