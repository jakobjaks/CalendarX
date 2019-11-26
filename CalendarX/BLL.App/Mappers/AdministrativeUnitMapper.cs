using System;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class AdministrativeUnitMapper  : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.AdministrativeUnit))
            {
                return MapFromDAL((internalDTO.AdministrativeUnit) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.AdministrativeUnit))
            {
                return MapFromBLL((externalDTO.AdministrativeUnit) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.AdministrativeUnit MapFromDAL(internalDTO.AdministrativeUnit administrativeUnit)
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
        
        public static internalDTO.AdministrativeUnit MapFromBLL(externalDTO.AdministrativeUnit administrativeUnit)
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