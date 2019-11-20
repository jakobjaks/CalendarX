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

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventInLocationController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public EventInLocationController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/EventInLocation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventInLocation>>> GetEventInLocations()
        {
            var res = await _uow.EventInLocationRepository.AllAsync();
            return Ok(res);
        }

        // GET: api/EventInLocation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventInLocation>> GetEventInLocation(int id)
        {
            var eventInLocation = await _uow.EventInLocationRepository.FindAsync(id);

            if (eventInLocation == null)
            {
                return NotFound();
            }

            return eventInLocation;
        }

        // PUT: api/EventInLocation/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventInLocation(int id, EventInLocation eventInLocation)
        {
            if (id != eventInLocation.Id)
            {
                return BadRequest();
            }

            _uow.EventInLocationRepository.Update(eventInLocation);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/EventInLocation
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EventInLocation>> PostEventInLocation(EventInLocation eventInLocation)
        {
            _uow.EventInLocationRepository.AddAsync(eventInLocation);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetEventInLocation", new { id = eventInLocation.Id }, eventInLocation);
        }

        // DELETE: api/EventInLocation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventInLocation>> DeleteEventInLocation(int id)
        {
            var eventInLocation = await _uow.EventInLocationRepository.FindAsync(id);
            if (eventInLocation == null)
            {
                return NotFound();
            }

            _uow.EventInLocationRepository.Remove(eventInLocation);
            await _uow.SaveChangesAsync();

            return eventInLocation;
        }

    }
}
