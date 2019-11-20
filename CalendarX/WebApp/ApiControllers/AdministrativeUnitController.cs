using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
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
    public class AdministrativeUnitController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public AdministrativeUnitController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/AdministrativeUnit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdministrativeUnit>>> GetAdministrativeUnits()
        {
            var res = await _uow.AdministrativeUnitRepository.AllAsync();
            return Ok(res);
        }

        // GET: api/AdministrativeUnit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdministrativeUnit>> GetAdministrativeUnit(int id)
        {
            var administrativeUnit = await _uow.AdministrativeUnitRepository.FindAsync(id);

            if (administrativeUnit == null)
            {
                return NotFound();
            }

            return administrativeUnit;
        }

        // PUT: api/AdministrativeUnit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrativeUnit(int id, AdministrativeUnit administrativeUnit)
        {
            if (id != administrativeUnit.Id)
            {
                return BadRequest();
            }

            _uow.AdministrativeUnitRepository.Update(administrativeUnit);
            await _uow.SaveChangesAsync();    

            return NoContent();
        }

        // POST: api/AdministrativeUnit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AdministrativeUnit>> PostAdministrativeUnit(AdministrativeUnit administrativeUnit)
        {
            await _uow.AdministrativeUnitRepository.AddAsync(administrativeUnit);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetAdministrativeUnit", new { id = administrativeUnit.Id }, administrativeUnit);
        }

        // DELETE: api/AdministrativeUnit/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdministrativeUnit>> DeleteAdministrativeUnit(int id)
        {
            var administrativeUnit = await _uow.AdministrativeUnitRepository.FindAsync(id);
            if (administrativeUnit == null)
            {
                return NotFound();
            }

            _uow.AdministrativeUnitRepository.Remove(administrativeUnit);
            await _uow.SaveChangesAsync();

            return administrativeUnit;
        }
        
    }
}
