//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Contracts.DAL.App;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using DAL;
//using DAL.App.EF;
//using Domain;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Cors;
//
//namespace WebApp.ApiControllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [EnableCors("MyPolicy")]
//    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
//    public class OrganizationOrganizingController : ControllerBase
//    {
//        private readonly IAppUnitOfWork _uow;
//
//        public OrganizationOrganizingController(IAppUnitOfWork uow)
//        {
//            _uow = uow;
//        }
//
//        // GET: api/OrganizationOrganizing
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<OrganizationOrganizing>>> GetOrganizationOrganizings()
//        {
//            var res = await _uow.OrganizationOrganizingRepository.AllAsync();
//            return Ok(res);
//        }
//
//        // GET: api/OrganizationOrganizing/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<OrganizationOrganizing>> GetOrganizationOrganizing(int id)
//        {
//            var organizationOrganizing = await _uow.OrganizationOrganizingRepository.FindAsync(id);
//
//            if (organizationOrganizing == null)
//            {
//                return NotFound();
//            }
//
//            return organizationOrganizing;
//        }
//
//        // PUT: api/OrganizationOrganizing/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutOrganizationOrganizing(int id, OrganizationOrganizing organizationOrganizing)
//        {
//            if (id != organizationOrganizing.Id)
//            {
//                return BadRequest();
//            }
//
//            _uow.OrganizationOrganizingRepository.Update(organizationOrganizing);
//            await _uow.SaveChangesAsync();
//
//            return NoContent();
//        }
//
//        // POST: api/OrganizationOrganizing
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPost]
//        public async Task<ActionResult<OrganizationOrganizing>> PostOrganizationOrganizing(OrganizationOrganizing organizationOrganizing)
//        {
//            await _uow.OrganizationOrganizingRepository.AddAsync(organizationOrganizing);
//            await _uow.SaveChangesAsync();
//
//            return CreatedAtAction("GetOrganizationOrganizing", new { id = organizationOrganizing.Id }, organizationOrganizing);
//        }
//
//        // DELETE: api/OrganizationOrganizing/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<OrganizationOrganizing>> DeleteOrganizationOrganizing(int id)
//        {
//            var organizationOrganizing = await _uow.OrganizationOrganizingRepository.FindAsync(id);
//            if (organizationOrganizing == null)
//            {
//                return NotFound();
//            }
//
//            _uow.OrganizationOrganizingRepository.Remove(organizationOrganizing);
//            await _uow.SaveChangesAsync();
//
//            return organizationOrganizing;
//        }
//
//    }
//}
