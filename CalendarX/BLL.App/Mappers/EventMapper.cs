using System;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class EventMapper  : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Event))
            {
                return MapFromDAL((internalDTO.Event) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Event))
            {
                return MapFromBLL((externalDTO.Event) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Event MapFromDAL(internalDTO.Event Event)
        {
            var res = Event == null ? null : new externalDTO.Event()
            {
                Id = Event.Id,
                Name = Event.Name,
                Description = Event.Description,   
                AppUserId = Event.AppUserId,
            };

            return res;
        }
        
        public static internalDTO.Event MapFromBLL(externalDTO.Event Event)
        {
            var res = Event == null ? null : new internalDTO.Event()
            {
                Id = Event.Id,
                Name = Event.Name,
                Description = Event.Description,     
                AppUserId = Event.AppUserId,
            };

            return res;
        }

    }
}