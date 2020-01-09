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

namespace WebApp.ApiControllers.v1._0
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PerformerController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public PerformerController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Performer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Performer>>> GetPerformers()
        {
            return (await _bll.Performers.AllAsync())
                .Select(e => PublicApi.v1.Mappers.PerformerMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/Performer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Performer>> GetPerformer(int id)
        {
            var performer = PublicApi.v1.Mappers.PerformerMapper.MapFromBLL(await _bll.Performers.FindAsync(id));

            if (performer == null)
            {
                return NotFound();
            }

            return performer;
        }

        // PUT: api/Performer/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerformer(int id, PublicApi.v1.DTO.Performer performer)
        {
            if (id != performer.Id)
            {
                return BadRequest();
            }
            if (await _bll.Performers.FindAsync(id) == null)
            {
                return NotFound();
            }
            _bll.Performers.Update(PublicApi.v1.Mappers.PerformerMapper.MapFromExternal(performer));
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/Performer
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Performer>> PostPerformer(PublicApi.v1.DTO.Performer performer)
        {
            
            performer = PublicApi.v1.Mappers.PerformerMapper.MapFromBLL(
                _bll.Performers.Add(PublicApi.v1.Mappers.PerformerMapper.MapFromExternal(performer)));
            await _bll.SaveChangesAsync();

            // get the new id into the object

            return CreatedAtAction("GetPerformer", new {id = performer.Id}, performer);
        }

        // DELETE: api/Performer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerformer(int id)
        {
            if (await _bll.Performers.FindAsync(id) == null)
            {
                return NotFound();
            }
            _bll.Performers.Remove(id);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

    }
}
