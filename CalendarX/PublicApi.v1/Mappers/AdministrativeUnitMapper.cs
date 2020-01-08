using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class AdministrativeUnitMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.AdministrativeUnit))
            {
                // map internal to external
                return MapFromBLL((internalDTO.AdministrativeUnit) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.AdministrativeUnit))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.AdministrativeUnit) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.AdministrativeUnit MapFromBLL(internalDTO.AdministrativeUnit AdministrativeUnit)
        {
            var res = AdministrativeUnit == null ? null : new externalDTO.AdministrativeUnit
            {
                Id = AdministrativeUnit.Id,
                Name = AdministrativeUnit.Name,
                Description = AdministrativeUnit.Description,   
                AppUserId = AdministrativeUnit.AppUserId,
            };

            return res;
        }

        public static internalDTO.AdministrativeUnit MapFromExternal(externalDTO.AdministrativeUnit AdministrativeUnit)
        {
            var res = AdministrativeUnit == null ? null : new internalDTO.AdministrativeUnit
            {
                Id = AdministrativeUnit.Id,
                Name = AdministrativeUnit.Name,
                Description = AdministrativeUnit.Description,   
                AppUserId = AdministrativeUnit.AppUserId,
            };
            return res;
        }
    }
}