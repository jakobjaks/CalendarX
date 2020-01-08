using System;
using Contracts.BLL.Base.Mappers;
using externalDTO = BLL.App.DTO;
using internalDTO = DAL.App.DTO;

namespace BLL.App.Mappers
{
    public class AreaOfInterestMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.AreaOfInterest))
            {
                // map internal to external
                return MapFromBLL((internalDTO.AreaOfInterest) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.AreaOfInterest))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.AreaOfInterest) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.AreaOfInterest MapFromBLL(internalDTO.AreaOfInterest areaOfInterest)
        {
            var res = areaOfInterest == null ? null : new externalDTO.AreaOfInterest
            {
                Id = areaOfInterest.Id,
                Name = areaOfInterest.Name,
                Description = areaOfInterest.Description,   
            };

            return res;
        }

        public static internalDTO.AreaOfInterest MapFromExternal(externalDTO.AreaOfInterest areaOfInterest)
        {
            var res = areaOfInterest == null ? null : new internalDTO.AreaOfInterest
            {
                Id = areaOfInterest.Id,
                Name = areaOfInterest.Name,
                Description = areaOfInterest.Description,   
            };
            return res;
        }
    }
}