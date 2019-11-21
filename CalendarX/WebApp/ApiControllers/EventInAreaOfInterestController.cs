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
    public class EventInAreaOfInterestController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public EventInAreaOfInterestController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/EventInAreaOfInterest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventInAreaOfInterest>>> GetEventInAreaOfInterests()
        {
            var res = await _uow.EventInAreaOfInterestRepository.AllAsync();
            return Ok(res);
        }

        // GET: api/EventInAreaOfInterest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventInAreaOfInterest>> GetEventInAreaOfInterest(int id)
        {
            var eventInAreaOfInterest = await _uow.EventInAreaOfInterestRepository.FindAsync(id);

            if (eventInAreaOfInterest == null)
            {
                return NotFound();
            }

            return eventInAreaOfInterest;
        }

        // PUT: api/EventInAreaOfInterest/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventInAreaOfInterest(int id, EventInAreaOfInterest eventInAreaOfInterest)
        {
            if (id != eventInAreaOfInterest.Id)
            {
                return BadRequest();
            }

            _uow.EventInAreaOfInterestRepository.Update(eventInAreaOfInterest);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/EventInAreaOfInterest
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EventInAreaOfInterest>> PostEventInAreaOfInterest(EventInAreaOfInterest eventInAreaOfInterest)
        {
            await _uow.EventInAreaOfInterestRepository.AddAsync(eventInAreaOfInterest);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetEventInAreaOfInterest", new { id = eventInAreaOfInterest.Id }, eventInAreaOfInterest);
        }

        // DELETE: api/EventInAreaOfInterest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventInAreaOfInterest>> DeleteEventInAreaOfInterest(int id)
        {
            var eventInAreaOfInterest = await _uow.EventInAreaOfInterestRepository.FindAsync(id);
            if (eventInAreaOfInterest == null)
            {
                return NotFound();
            }

            _uow.EventInAreaOfInterestRepository.Remove(eventInAreaOfInterest);
            await _uow.SaveChangesAsync();

            return eventInAreaOfInterest;
        }
        
    }
}
