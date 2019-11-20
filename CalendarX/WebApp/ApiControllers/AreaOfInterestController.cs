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
    public class AreaOfInterestController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public AreaOfInterestController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/AreaOfInterest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaOfInterest>>> GetAreaOfInterests()
        {
            var res = await _uow.AreaOfInterestRepository.AllAsync();
            return Ok(res);
        }

        // GET: api/AreaOfInterest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AreaOfInterest>> GetAreaOfInterest(int id)
        {
            var areaOfInterest = await _uow.AreaOfInterestRepository.FindAsync(id);

            if (areaOfInterest == null)
            {
                return NotFound();
            }

            return areaOfInterest;
        }

        // PUT: api/AreaOfInterest/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAreaOfInterest(int id, AreaOfInterest areaOfInterest)
        {
            if (id != areaOfInterest.Id)
            {
                return BadRequest();
            }

            _uow.AreaOfInterestRepository.Update(areaOfInterest);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/AreaOfInterest
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AreaOfInterest>> PostAreaOfInterest(AreaOfInterest areaOfInterest)
        {
            await _uow.AreaOfInterestRepository.AddAsync(areaOfInterest);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetAreaOfInterest", new { id = areaOfInterest.Id }, areaOfInterest);
        }

        // DELETE: api/AreaOfInterest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AreaOfInterest>> DeleteAreaOfInterest(int id)
        {
            var areaOfInterest = await _uow.AreaOfInterestRepository.FindAsync(id);
            if (areaOfInterest == null)
            {
                return NotFound();
            }

            _uow.AreaOfInterestRepository.Remove(areaOfInterest);
            await _uow.SaveChangesAsync();

            return areaOfInterest;
        }


    }
}
