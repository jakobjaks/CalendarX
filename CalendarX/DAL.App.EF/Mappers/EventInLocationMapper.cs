using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class EventInLocationMapper  : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.EventInLocation))
            {
                return MapFromDomain((internalDTO.EventInLocation) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.EventInLocation))
            {
                return MapFromDAL((externalDTO.EventInLocation) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.EventInLocation MapFromDomain(internalDTO.EventInLocation eventInLocation)
        {
            var res = eventInLocation == null ? null : new externalDTO.EventInLocation()
            {
                Id = eventInLocation.Id,
                Location = LocationMapper.MapFromDomain(eventInLocation.Location),
                LocationId = eventInLocation.LocationId,
                Event = EventMapper.MapFromDomain(eventInLocation.Event),
                EventId = eventInLocation.EventId
            };

            return res;
        }
        
        public static internalDTO.EventInLocation MapFromDAL(externalDTO.EventInLocation eventInLocation)
        {
            var res = eventInLocation == null ? null : new internalDTO.EventInLocation()
            {
                Id = eventInLocation.Id,
                Location = LocationMapper.MapFromDAL(eventInLocation.Location),
                LocationId = eventInLocation.LocationId,
                Event = EventMapper.MapFromDAL(eventInLocation.Event),
                EventId = eventInLocation.EventId
            };

            return res;
        }

    }
}