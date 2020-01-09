using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Identity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BLL.Base;

namespace WebApp.ApiControllers.v1._0
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AdministrativeUnitController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public AdministrativeUnitController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/AdministrativeUnit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.AdministrativeUnit>>> GetAdministrativeUnits()
        {
            return (await _bll.AdministrativeUnits.AllAsync())
                .Select(e => PublicApi.v1.Mappers.AdministrativeUnitMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/AdministrativeUnit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.AdministrativeUnit>> GetAdministrativeUnit(int id)
        {
            var administrativeUnit = PublicApi.v1.Mappers.AdministrativeUnitMapper.MapFromBLL(await _bll.AdministrativeUnits.FindAsync(id));

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
        public async Task<IActionResult> PutAdministrativeUnit(int id, PublicApi.v1.DTO.AdministrativeUnit administrativeUnit)
        {
            if (id != administrativeUnit.Id)
            {
                return BadRequest();
            }

            // check for the ownership - is this Person record really belonging to logged in user.
            if (!await _bll.AdministrativeUnits.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            administrativeUnit.AppUserId = User.GetUserId();

            _bll.AdministrativeUnits.Update(PublicApi.v1.Mappers.AdministrativeUnitMapper.MapFromExternal(administrativeUnit));
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/AdministrativeUnit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AdministrativeUnit>> PostAdministrativeUnit(PublicApi.v1.DTO.AdministrativeUnit administrativeUnit)
        {
            administrativeUnit.AppUserId = User.GetUserId();

            administrativeUnit = PublicApi.v1.Mappers.AdministrativeUnitMapper.MapFromBLL(
                _bll.AdministrativeUnits.Add(PublicApi.v1.Mappers.AdministrativeUnitMapper.MapFromExternal(administrativeUnit)));
            await _bll.SaveChangesAsync();
            administrativeUnit = PublicApi.v1.Mappers.AdministrativeUnitMapper.MapFromBLL(
                _bll.AdministrativeUnits.GetUpdatesAfterUOWSaveChanges(PublicApi.v1.Mappers.AdministrativeUnitMapper.MapFromExternal(administrativeUnit)));

            // get the new id into the object

            return CreatedAtAction("GetAdministrativeUnit", new {id = administrativeUnit.Id}, administrativeUnit);
        }

        // DELETE: api/AdministrativeUnit/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdministrativeUnit(int id)
        {
            // check for the ownership - is this Person record really belonging to logged in user.
            if (!await _bll.AdministrativeUnits.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.AdministrativeUnits.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
