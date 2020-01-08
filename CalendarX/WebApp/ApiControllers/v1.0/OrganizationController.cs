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
    public class OrganizationController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public OrganizationController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Organization
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Organization>>> GetOrganizations()
        {
            return (await _bll.Organizations.AllAsync())
                .Select(e => PublicApi.v1.Mappers.OrganizationMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/Organization/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Organization>> GetOrganization(int id)
        {
            var organization = PublicApi.v1.Mappers.OrganizationMapper.MapFromBLL(await _bll.Organizations.FindAsync(id));

            if (organization == null)
            {
                return NotFound();
            }

            return organization;
        }

        // PUT: api/Organization/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganization(int id, PublicApi.v1.DTO.Organization organization)
        {
            organization.AppUserId = User.GetUserId();

            if (id != organization.Id)
            {
                return BadRequest();
            }
            if (await _bll.Organizations.FindAsync(id) == null)
            {
                return NotFound();
            }
            _bll.Organizations.Update(PublicApi.v1.Mappers.OrganizationMapper.MapFromExternal(organization));
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/Organization
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Organization>> PostOrganization(PublicApi.v1.DTO.Organization organization)
        {
            organization.AppUserId = User.GetUserId();
            
            organization = PublicApi.v1.Mappers.OrganizationMapper.MapFromBLL(
                _bll.Organizations.Add(PublicApi.v1.Mappers.OrganizationMapper.MapFromExternal(organization)));
            await _bll.SaveChangesAsync();

            // get the new id into the object

            return CreatedAtAction("GetOrganization", new {id = organization.Id}, organization);
        }

        // DELETE: api/Organization/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrganization(int id)
        {
            if (await _bll.Organizations.FindAsync(id) == null)
            {
                return NotFound();
            }
            _bll.Organizations.Remove(id);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

    }
}
