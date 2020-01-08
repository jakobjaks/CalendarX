using System;
using Contracts.BLL.Base.Mappers;
using externalDTO = BLL.App.DTO;
using internalDTO = DAL.App.DTO;

namespace BLL.App.Mappers
{
    public class OrganizationMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Organization))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Organization) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Organization))
            {
                // map from external to internal
                return MapFromExternal((externalDTO.Organization) inObject) as TOutObject;
            }
            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Organization MapFromBLL(internalDTO.Organization organization)
        {
            var res = organization == null ? null : new externalDTO.Organization
            {
                Id = organization.Id,
                Name = organization.Name,
                Description = organization.Description,   
                AppUserId = organization.AppUserId,
            };

            return res;
        }

        public static internalDTO.Organization MapFromExternal(externalDTO.Organization organization)
        {
            var res = organization == null ? null : new internalDTO.Organization
            {
                Id = organization.Id,
                Name = organization.Name,
                Description = organization.Description,   
                AppUserId = organization.AppUserId,
            };
            return res;
        }
    }
}