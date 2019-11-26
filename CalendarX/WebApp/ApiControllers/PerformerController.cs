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
//    public class PerformerController : ControllerBase
//    {
//        private readonly IAppUnitOfWork _uow;
//
//        public PerformerController(IAppUnitOfWork uow)
//        {
//            _uow = uow;
//        }
//
//        // GET: api/Performer
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Performer>>> GetPerformers()
//        {
//            var res = await _uow.PerformerRepository.AllAsync();
//            return Ok(res);
//        }
//
//        // GET: api/Performer/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Performer>> GetPerformer(int id)
//        {
//            var performer = await _uow.PerformerRepository.FindAsync(id);
//
//            if (performer == null)
//            {
//                return NotFound();
//            }
//
//            return performer;
//        }
//
//        // PUT: api/Performer/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutPerformer(int id, Performer performer)
//        {
//            if (id != performer.Id)
//            {
//                return BadRequest();
//            }
//
//            _uow.PerformerRepository.Update(performer);
//            await _uow.SaveChangesAsync();
//
//            return NoContent();
//        }
//
//        // POST: api/Performer
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPost]
//        public async Task<ActionResult<Performer>> PostPerformer(Performer performer)
//        {
//            await _uow.PerformerRepository.AddAsync(performer);
//            await _uow.SaveChangesAsync();
//
//            return CreatedAtAction("GetPerformer", new { id = performer.Id }, performer);
//        }
//
//        // DELETE: api/Performer/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Performer>> DeletePerformer(int id)
//        {
//            var performer = await _uow.PerformerRepository.FindAsync(id);
//            if (performer == null)
//            {
//                return NotFound();
//            }
//
//            _uow.PerformerRepository.Remove(performer);
//            await _uow.SaveChangesAsync();
//
//            return performer;
//        }
//
//    }
//}
