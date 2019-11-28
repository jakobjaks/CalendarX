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

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LocationController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public LocationController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Location
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Location>>> GetLocations()
        {
            return (await _bll.Locations.AllAsync())
                .Select(e => PublicApi.v1.Mappers.LocationMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/Location/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Location>> GetLocation(int id)
        {
            var administrativeUnit = PublicApi.v1.Mappers.LocationMapper.MapFromBLL(await _bll.Locations.FindForUserAsync(id, User.GetUserId()));

            if (administrativeUnit == null)
            {
                return NotFound();
            }

            return administrativeUnit;
        }

        // PUT: api/Location/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, PublicApi.v1.DTO.Location administrativeUnit)
        {
            if (id != administrativeUnit.Id)
            {
                return BadRequest();
            }

            // check for the ownership - is this Person record really belonging to logged in user.
            if (!await _bll.Locations.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            administrativeUnit.AppUserId = User.GetUserId();

            _bll.Locations.Update(PublicApi.v1.Mappers.LocationMapper.MapFromExternal(administrativeUnit));
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/Location
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(PublicApi.v1.DTO.Location administrativeUnit)
        {
            administrativeUnit.AppUserId = User.GetUserId();

            administrativeUnit = PublicApi.v1.Mappers.LocationMapper.MapFromBLL(
                _bll.Locations.Add(PublicApi.v1.Mappers.LocationMapper.MapFromExternal(administrativeUnit)));
            await _bll.SaveChangesAsync();
            administrativeUnit = PublicApi.v1.Mappers.LocationMapper.MapFromBLL(
                _bll.Locations.GetUpdatesAfterUOWSaveChanges(PublicApi.v1.Mappers.LocationMapper.MapFromExternal(administrativeUnit)));

            // get the new id into the object

            return CreatedAtAction("GetLocation", new {id = administrativeUnit.Id}, administrativeUnit);
        }

        // DELETE: api/Location/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLocation(int id)
        {
            // check for the ownership - is this Person record really belonging to logged in user.
            if (!await _bll.Locations.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.Locations.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
