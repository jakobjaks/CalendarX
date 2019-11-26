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
//    public class PerformerInEventController : ControllerBase
//    {
//        private readonly IAppUnitOfWork _uow;
//
//        public PerformerInEventController(IAppUnitOfWork uow)
//        {
//            _uow = uow;
//        }
//
//        // GET: api/PerformerInEvent
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<PerformerInEvent>>> GetPerformerInEvents()
//        {
//            var res = await _uow.PerformerInEventRepository.AllAsync();
//            return Ok(res);
//        }
//
//        // GET: api/PerformerInEvent/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<PerformerInEvent>> GetPerformerInEvent(int id)
//        {
//            var performerInEvent = await _uow.PerformerInEventRepository.FindAsync(id);
//
//            if (performerInEvent == null)
//            {
//                return NotFound();
//            }
//
//            return performerInEvent;
//        }
//
//        // PUT: api/PerformerInEvent/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutPerformerInEvent(int id, PerformerInEvent performerInEvent)
//        {
//            if (id != performerInEvent.Id)
//            {
//                return BadRequest();
//            }
//
//            _uow.PerformerInEventRepository.Update(performerInEvent);
//            await _uow.SaveChangesAsync();
//
//            return NoContent();
//        }
//
//        // POST: api/PerformerInEvent
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPost]
//        public async Task<ActionResult<PerformerInEvent>> PostPerformerInEvent(PerformerInEvent performerInEvent)
//        {
//            await _uow.PerformerInEventRepository.AddAsync(performerInEvent);
//            await _uow.SaveChangesAsync();
//
//            return CreatedAtAction("GetPerformerInEvent", new { id = performerInEvent.Id }, performerInEvent);
//        }
//
//        // DELETE: api/PerformerInEvent/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<PerformerInEvent>> DeletePerformerInEvent(int id)
//        {
//            var performerInEvent = await _uow.PerformerInEventRepository.FindAsync(id);
//            if (performerInEvent == null)
//            {
//                return NotFound();
//            }
//
//            _uow.PerformerInEventRepository.Remove(performerInEvent);
//            await _uow.SaveChangesAsync();
//
//            return performerInEvent;
//        }
//
//
//    }
//}
