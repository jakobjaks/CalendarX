using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EventTargetAudienceController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public EventTargetAudienceController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/EventTargetAudience
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventTargetAudience>>> GetEventTargetAudiences()
        {
            var res = await _uow.EventTargetAudienceRepository.AllAsync();
            return Ok(res);
        }

        // GET: api/EventTargetAudience/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventTargetAudience>> GetEventTargetAudience(int id)
        {
            var eventTargetAudience = await _uow.EventTargetAudienceRepository.FindAsync(id);

            if (eventTargetAudience == null)
            {
                return NotFound();
            }

            return eventTargetAudience;
        }

        // PUT: api/EventTargetAudience/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventTargetAudience(int id, EventTargetAudience eventTargetAudience)
        {
            if (id != eventTargetAudience.Id)
            {
                return BadRequest();
            }

            _uow.EventTargetAudienceRepository.Update(eventTargetAudience);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/EventTargetAudience
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EventTargetAudience>> PostEventTargetAudience(EventTargetAudience eventTargetAudience)
        {
            await _uow.EventTargetAudienceRepository.AddAsync(eventTargetAudience);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetEventTargetAudience", new { id = eventTargetAudience.Id }, eventTargetAudience);
        }

        // DELETE: api/EventTargetAudience/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventTargetAudience>> DeleteEventTargetAudience(int id)
        {
            var eventTargetAudience = await _uow.EventTargetAudienceRepository.FindAsync(id);
            if (eventTargetAudience == null)
            {
                return NotFound();
            }

            _uow.EventTargetAudienceRepository.Remove(eventTargetAudience);
            await _uow.SaveChangesAsync();

            return eventTargetAudience;
        }
        
    }
}
