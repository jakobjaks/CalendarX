using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class PerformerMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Performer))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Performer) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Performer))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.Performer) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Performer MapFromBLL(internalDTO.Performer performer)
        {
            var res = performer == null ? null : new externalDTO.Performer
            {
                Id = performer.Id,
                Name = performer.Name,
                Description = performer.Description,   
            };

            return res;
        }

        public static internalDTO.Performer MapFromExternal(externalDTO.Performer performer)
        {
            var res = performer == null ? null : new internalDTO.Performer
            {
                Id = performer.Id,
                Name = performer.Name,
                Description = performer.Description,   
            };
            return res;
        }
    }
}