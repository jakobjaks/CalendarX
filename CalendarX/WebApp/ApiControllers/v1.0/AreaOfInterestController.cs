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
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AreaOfInterestController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public AreaOfInterestController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/AreaOfInterest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.AreaOfInterest>>> GetAreaOfInterests()
        {
            return (await _bll.AreaOfInterests.AllAsync())
                .Select(e => PublicApi.v1.Mappers.AreaOfInterestMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/AreaOfInterest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.AreaOfInterest>> GetAreaOfInterest(int id)
        {
            var areaOfInterest = PublicApi.v1.Mappers.AreaOfInterestMapper.MapFromBLL(await _bll.AreaOfInterests.FindAsync(id));

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
        public async Task<IActionResult> PutAreaOfInterest(int id, PublicApi.v1.DTO.AreaOfInterest areaOfInterest)
        {
            if (id != areaOfInterest.Id)
            {
                return BadRequest();
            }
            if (await _bll.AreaOfInterests.FindAsync(id) == null)
            {
                return NotFound();
            }
            _bll.AreaOfInterests.Update(PublicApi.v1.Mappers.AreaOfInterestMapper.MapFromExternal(areaOfInterest));
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/AreaOfInterest
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AreaOfInterest>> PostAreaOfInterest(PublicApi.v1.DTO.AreaOfInterest areaOfInterest)
        {
            areaOfInterest = PublicApi.v1.Mappers.AreaOfInterestMapper.MapFromBLL(
                _bll.AreaOfInterests.Add(PublicApi.v1.Mappers.AreaOfInterestMapper.MapFromExternal(areaOfInterest)));
            await _bll.SaveChangesAsync();

            // get the new id into the object

            return CreatedAtAction("GetAreaOfInterest", new {id = areaOfInterest.Id}, areaOfInterest);
        }

        // DELETE: api/AreaOfInterest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAreaOfInterest(int id)
        {
            if (await _bll.AreaOfInterests.FindAsync(id) == null)
            {
                return NotFound();
            }
            _bll.AreaOfInterests.Remove(id);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

    }
}
