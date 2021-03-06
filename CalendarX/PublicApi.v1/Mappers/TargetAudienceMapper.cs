using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class TargetAudienceMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.TargetAudience))
            {
                // map internal to external
                return MapFromBLL((internalDTO.TargetAudience) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.TargetAudience))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.TargetAudience) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.TargetAudience MapFromBLL(internalDTO.TargetAudience targetAudience)
        {
            var res = targetAudience == null ? null : new externalDTO.TargetAudience
            {
                Id = targetAudience.Id,
                Name = targetAudience.Name,
                Description = targetAudience.Description,   
            };

            return res;
        }

        public static internalDTO.TargetAudience MapFromExternal(externalDTO.TargetAudience targetAudience)
        {
            var res = targetAudience == null ? null : new internalDTO.TargetAudience
            {
                Id = targetAudience.Id,
                Name = targetAudience.Name,
                Description = targetAudience.Description,   
            };
            return res;
        }
    }
}