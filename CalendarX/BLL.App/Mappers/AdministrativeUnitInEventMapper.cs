using System;
using System.Collections;
using System.Collections.Generic;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class AdministrativeUnitInEventMapper  : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.AdministrativeUnitInEvent))
            {
                return MapFromDAL((internalDTO.AdministrativeUnitInEvent) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.AdministrativeUnitInEvent))
            {
                return MapFromBLL((externalDTO.AdministrativeUnitInEvent) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.AdministrativeUnitInEvent MapFromDAL(internalDTO.AdministrativeUnitInEvent administrativeUnit)
        {
            var res = administrativeUnit == null ? null : new externalDTO.AdministrativeUnitInEvent()
            {
                Id = administrativeUnit.Id,
                EventId = administrativeUnit.EventId,
                Event = EventMapper.MapFromDAL(administrativeUnit.Event),
                AdministrativeUnit = AdministrativeUnitMapper.MapFromDAL(administrativeUnit.AdministrativeUnit),
                AdministrativeUnitId = administrativeUnit.AdministrativeUnitId
            };

            return res;
        }
        
        public static internalDTO.AdministrativeUnitInEvent MapFromBLL(externalDTO.AdministrativeUnitInEvent administrativeUnit)
        {
            var res = administrativeUnit == null ? null : new internalDTO.AdministrativeUnitInEvent()
            {
                Id = administrativeUnit.Id,
                EventId = administrativeUnit.EventId,
                Event = EventMapper.MapFromBLL(administrativeUnit.Event),
                AdministrativeUnit = AdministrativeUnitMapper.MapFromBLL(administrativeUnit.AdministrativeUnit),
                AdministrativeUnitId = administrativeUnit.AdministrativeUnitId
            };

            return res;
        }

        public static ICollection<internalDTO.AdministrativeUnitInEvent> MapListFromBLL(ICollection<externalDTO.AdministrativeUnitInEvent> administrativeUnitInEvents)
        {
            var list = new List<internalDTO.AdministrativeUnitInEvent>();
            foreach (var administrativeUnitInEvent in administrativeUnitInEvents)
            {
                list.Add(MapFromBLL(administrativeUnitInEvent));
            }

            return list;
        }

    }
}