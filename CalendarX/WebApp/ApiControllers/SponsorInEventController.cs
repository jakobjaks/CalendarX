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
    public class SponsorInEventController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public SponsorInEventController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/SponsorInEvent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SponsorInEvent>>> GetSponsorInEvents()
        {
            var res = await _uow.SponsorInEventRepository.AllAsync();
            return Ok(res);
        }

        // GET: api/SponsorInEvent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SponsorInEvent>> GetSponsorInEvent(int id)
        {
            var sponsorInEvent = await _uow.SponsorInEventRepository.FindAsync(id);

            if (sponsorInEvent == null)
            {
                return NotFound();
            }

            return sponsorInEvent;
        }

        // PUT: api/SponsorInEvent/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSponsorInEvent(int id, SponsorInEvent sponsorInEvent)
        {
            if (id != sponsorInEvent.Id)
            {
                return BadRequest();
            }

            _uow.SponsorInEventRepository.Update(sponsorInEvent);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SponsorInEvent
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SponsorInEvent>> PostSponsorInEvent(SponsorInEvent sponsorInEvent)
        {
            _uow.SponsorInEventRepository.AddAsync(sponsorInEvent);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetSponsorInEvent", new { id = sponsorInEvent.Id }, sponsorInEvent);
        }

        // DELETE: api/SponsorInEvent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SponsorInEvent>> DeleteSponsorInEvent(int id)
        {
            var sponsorInEvent = await _uow.SponsorInEventRepository.FindAsync(id);
            if (sponsorInEvent == null)
            {
                return NotFound();
            }

            _uow.SponsorInEventRepository.Remove(sponsorInEvent);
            await _uow.SaveChangesAsync();

            return sponsorInEvent;
        }
        
    }
}
