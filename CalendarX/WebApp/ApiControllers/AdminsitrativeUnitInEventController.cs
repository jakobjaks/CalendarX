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
    public class AdminsitrativeUnitInEventController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public AdminsitrativeUnitInEventController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/AdminsitrativeUnitInEvent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdministrativeUnitInEvent>>> GetAdministrativeUnitInEvents()
        {
            var res = await _uow.AdministrativeUnitRepository.AllAsync();
            return Ok(res);
        }

        // GET: api/AdminsitrativeUnitInEvent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdministrativeUnitInEvent>> GetAdministrativeUnitInEvent(int id)
        {
            var administrativeUnitInEvent = await _uow.AdministrativeUnitInEventRepository.FindAsync(id);

            if (administrativeUnitInEvent == null)
            {
                return NotFound();
            }

            return administrativeUnitInEvent;
        }

        // PUT: api/AdminsitrativeUnitInEvent/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrativeUnitInEvent(int id, AdministrativeUnitInEvent administrativeUnitInEvent)
        {
            if (id != administrativeUnitInEvent.Id)
            {
                return BadRequest();
            }

            _uow.AdministrativeUnitInEventRepository.Update(administrativeUnitInEvent);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/AdminsitrativeUnitInEvent
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AdministrativeUnitInEvent>> PostAdministrativeUnitInEvent(AdministrativeUnitInEvent administrativeUnitInEvent)
        {
            await _uow.AdministrativeUnitInEventRepository.AddAsync(administrativeUnitInEvent);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetAdministrativeUnitInEvent", new { id = administrativeUnitInEvent.Id }, administrativeUnitInEvent);
        }

        // DELETE: api/AdminsitrativeUnitInEvent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdministrativeUnitInEvent>> DeleteAdministrativeUnitInEvent(int id)
        {
            var administrativeUnitInEvent = await _uow.AdministrativeUnitInEventRepository.FindAsync(id);
            if (administrativeUnitInEvent == null)
            {
                return NotFound();
            }

            _uow.AdministrativeUnitInEventRepository.Remove(administrativeUnitInEvent);
            await _uow.SaveChangesAsync();

            return administrativeUnitInEvent;
        }


    }
}
