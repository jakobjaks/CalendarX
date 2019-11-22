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
using Microsoft.AspNetCore.Cors;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TargetAudienceController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public TargetAudienceController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/TargetAudience
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TargetAudience>>> GetTargetAudiences()
        {
            var res = await _uow.TargetAudienceRepository.AllAsync();
            return Ok(res);
        }

        // GET: api/TargetAudience/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TargetAudience>> GetTargetAudience(int id)
        {
            var targetAudience = await _uow.TargetAudienceRepository.FindAsync(id);

            if (targetAudience == null)
            {
                return NotFound();
            }

            return targetAudience;
        }

        // PUT: api/TargetAudience/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTargetAudience(int id, TargetAudience targetAudience)
        {
            if (id != targetAudience.Id)
            {
                return BadRequest();
            }

            _uow.TargetAudienceRepository.Update(targetAudience);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/TargetAudience
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TargetAudience>> PostTargetAudience(TargetAudience targetAudience)
        {
            await _uow.TargetAudienceRepository.AddAsync(targetAudience);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetTargetAudience", new { id = targetAudience.Id }, targetAudience);
        }

        // DELETE: api/TargetAudience/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TargetAudience>> DeleteTargetAudience(int id)
        {
            var targetAudience = await _uow.TargetAudienceRepository.FindAsync(id);
            if (targetAudience == null)
            {
                return NotFound();
            }

            _uow.TargetAudienceRepository.Remove(targetAudience);
            await _uow.SaveChangesAsync();

            return targetAudience;
        }

    }
}
