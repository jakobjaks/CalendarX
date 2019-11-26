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
    public class EventController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public EventController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Event>>> GetEvents()
        {
            return (await _bll.Events.AllAsync())
                .Select(e => PublicApi.v1.Mappers.EventMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Event>> GetEvent(int id)
        {
            var @event = PublicApi.v1.Mappers.EventMapper.MapFromBLL(await _bll.Events.FindForUserAsync(id, User.GetUserId()));

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        // PUT: api/Event/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, PublicApi.v1.DTO.Event @event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }

            // check for the ownership - is this Person record really belonging to logged in user.
            if (!await _bll.Events.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            @event.AppUserId = User.GetUserId();

            _bll.Events.Update(PublicApi.v1.Mappers.EventMapper.MapFromExternal(@event));
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/Event
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(PublicApi.v1.DTO.Event @event)
        {
            @event.AppUserId = User.GetUserId();

            @event = PublicApi.v1.Mappers.EventMapper.MapFromBLL(
                _bll.Events.Add(PublicApi.v1.Mappers.EventMapper.MapFromExternal(@event)));
            await _bll.SaveChangesAsync();
            @event = PublicApi.v1.Mappers.EventMapper.MapFromBLL(
                _bll.Events.GetUpdatesAfterUOWSaveChanges(PublicApi.v1.Mappers.EventMapper.MapFromExternal(@event)));

            // get the new id into the object

            return CreatedAtAction("GetEvent", new {id = @event.Id}, @event);
        }

        // DELETE: api/Event/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            // check for the ownership - is this Person record really belonging to logged in user.
            if (!await _bll.Events.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.Events.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
