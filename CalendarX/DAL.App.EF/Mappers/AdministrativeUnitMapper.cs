using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class AdministrativeUnitMapper  : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.AdministrativeUnit))
            {
                return MapFromDomain((internalDTO.AdministrativeUnit) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.AdministrativeUnit))
            {
                return MapFromDAL((externalDTO.AdministrativeUnit) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.AdministrativeUnit MapFromDomain(internalDTO.AdministrativeUnit administrativeUnit)
        {
            var res = administrativeUnit == null ? null : new externalDTO.AdministrativeUnit()
            {
                Id = administrativeUnit.Id,
                Name = administrativeUnit.Name,
                Description = administrativeUnit.Description,
                AppUserId = administrativeUnit.AppUserId,
            };

            return res;
        }
        
        public static internalDTO.AdministrativeUnit MapFromDAL(externalDTO.AdministrativeUnit administrativeUnit)
        {
            var res = administrativeUnit == null ? null : new internalDTO.AdministrativeUnit()
            {
                Id = administrativeUnit.Id,
                Name = administrativeUnit.Name,
                Description = administrativeUnit.Description,
                AppUserId = administrativeUnit.AppUserId,

            };

            return res;
        }

    }
}