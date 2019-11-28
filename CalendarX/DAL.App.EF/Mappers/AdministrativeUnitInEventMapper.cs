using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class AdministrativeUnitInEventMapper  : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.AdministrativeUnitInEvent))
            {
                return MapFromDomain((internalDTO.AdministrativeUnitInEvent) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.AdministrativeUnitInEvent))
            {
                return MapFromDAL((externalDTO.AdministrativeUnitInEvent) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.AdministrativeUnitInEvent MapFromDomain(internalDTO.AdministrativeUnitInEvent administrativeUnitInEvent)
        {
            var res = administrativeUnitInEvent == null ? null : new externalDTO.AdministrativeUnitInEvent()
            {
                EventId = administrativeUnitInEvent.EventId,
                AdministrativeUnitId = administrativeUnitInEvent.AdministrativeUnitId
            };

            return res;
        }
        
        public static internalDTO.AdministrativeUnitInEvent MapFromDAL(externalDTO.AdministrativeUnitInEvent administrativeUnitInEvent)
        {
            var res = administrativeUnitInEvent == null ? null : new internalDTO.AdministrativeUnitInEvent()
            {
                EventId = administrativeUnitInEvent.EventId,
                AdministrativeUnitId = administrativeUnitInEvent.AdministrativeUnitId
            };

            return res;
        }

    }
}