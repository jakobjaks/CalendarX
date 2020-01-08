using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class LocationMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Location))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Location) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Location))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.Location) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Location MapFromBLL(internalDTO.Location Location)
        {
            var res = Location == null ? null : new externalDTO.Location
            {
                Id = Location.Id,
                Name = Location.Name,
                Description = Location.Description,   
                AppUserId = Location.AppUserId,
            };

            return res;
        }

        public static internalDTO.Location MapFromExternal(externalDTO.Location Location)
        {
            var res = Location == null ? null : new internalDTO.Location
            {
                Id = Location.Id,
                Name = Location.Name,
                Description = Location.Description,   
                AppUserId = Location.AppUserId,
            };
            return res;
        }
    }
}