using System;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class LocationMapper  : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Location))
            {
                return MapFromDAL((internalDTO.Location) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Location))
            {
                return MapFromBLL((externalDTO.Location) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Location MapFromDAL(internalDTO.Location location)
        {
            var res = location == null ? null : new externalDTO.Location()
            {
                Id = location.Id,
                Name = location.Name,
                Description = location.Description,   
                AppUserId = location.AppUserId,
            };

            return res;
        }
        
        public static internalDTO.Location MapFromBLL(externalDTO.Location location)
        {
            var res = location == null ? null : new internalDTO.Location()
            {
                Id = location.Id,
                Name = location.Name,
                Description = location.Description,     
                AppUserId = location.AppUserId,
            };

            return res;
        }

    }
}