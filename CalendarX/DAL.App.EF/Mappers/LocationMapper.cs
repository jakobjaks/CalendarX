using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class LocationMapper  : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Location))
            {
                return MapFromDomain((internalDTO.Location) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Location))
            {
                return MapFromDAL((externalDTO.Location) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Location MapFromDomain(internalDTO.Location Location)
        {
            var res = Location == null ? null : new externalDTO.Location()
            {
                Id = Location.Id,
                Name = Location.Name,
                Description = Location.Description                
            };

            return res;
        }
        
        public static internalDTO.Location MapFromDAL(externalDTO.Location Location)
        {
            var res = Location == null ? null : new internalDTO.Location()
            {
                Id = Location.Id,
                Name = Location.Name,
                Description = Location.Description
            };

            return res;
        }

    }
}