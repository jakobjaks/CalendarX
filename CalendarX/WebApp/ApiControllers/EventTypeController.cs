using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.BLL.Base;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Domain;
using Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EventTypeController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public EventTypeController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/EventType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.EventType>>> GetEventTypes()
        {
            return (await _bll.EventTypes.AllAsync())
                .Select(e => PublicApi.v1.Mappers.EventTypeMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/EventType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.EventType>> GetEventType(int id)
        {
            var administrativeUnit = PublicApi.v1.Mappers.EventTypeMapper.MapFromBLL(await _bll.EventTypes.FindAsync(id, User.GetUserId()));

            if (administrativeUnit == null)
            {
                return NotFound();
            }

            return administrativeUnit;
        }

        // PUT: api/EventType/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventType(int id, PublicApi.v1.DTO.EventType administrativeUnit)
        {
            if (id != administrativeUnit.Id)
            {
                return BadRequest();
            }
            

            administrativeUnit.AppUserId = User.GetUserId();

            _bll.EventTypes.Update(PublicApi.v1.Mappers.EventTypeMapper.MapFromExternal(administrativeUnit));
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/EventType
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EventType>> PostEventType(PublicApi.v1.DTO.EventType administrativeUnit)
        {
            administrativeUnit.AppUserId = User.GetUserId();

            administrativeUnit = PublicApi.v1.Mappers.EventTypeMapper.MapFromBLL(
                _bll.EventTypes.Add(PublicApi.v1.Mappers.EventTypeMapper.MapFromExternal(administrativeUnit)));
            await _bll.SaveChangesAsync();
            administrativeUnit = PublicApi.v1.Mappers.EventTypeMapper.MapFromBLL(
                _bll.EventTypes.GetUpdatesAfterUOWSaveChanges(PublicApi.v1.Mappers.EventTypeMapper.MapFromExternal(administrativeUnit)));

            // get the new id into the object

            return CreatedAtAction("GetEventType", new {id = administrativeUnit.Id}, administrativeUnit);
        }

        // DELETE: api/EventType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEventType(int id)
        {

            _bll.EventTypes.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
