using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.AspNetCore.Hosting;

namespace WebApp.ApiControllers.v1._0
{
    [ApiVersion("1.0")]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EventController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IHostingEnvironment hostingEnvironment;

        public EventController(IAppBLL bll, IHostingEnvironment hostingEnvironment)
        {
            _bll = bll;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Event>>> GetEvents()
        {
            return (await _bll.Events.AllAsync())
                .Select(e => PublicApi.v1.Mappers.EventMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Event>> GetEvent(int id)
        {
            var @event = PublicApi.v1.Mappers.EventMapper.MapFromBLL(await _bll.Events.FindAsync(id));

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }
        
        // GET: api/Event/5
        [HttpGet("{search}/{topic}")]
        public async Task<List<BLL.App.DTO.Event>> GetEventSearch(string search, int topic)
        {
            var @event = await _bll.Events.SearchByCategory(search, topic);

            return @event;
        }

        // PUT: api/Event/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, PublicApi.v1.DTO.Event @event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }

            // check for the ownership - is this Person record really belonging to logged in user.
            if (!await _bll.Events.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            @event.AppUserId = User.GetUserId();

            _bll.Events.Update(PublicApi.v1.Mappers.EventMapper.MapFromExternal(@event));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Event
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Route("image")]
        public async Task<IActionResult> SaveImage([FromForm]IFormFile file)
        {
            var form = await Request.ReadFormAsync();

            var testfile = form.Files[0];
            Console.WriteLine("Images controller");
            var filePath = "wwwroot/images" + "/" + testfile.FileName;
            
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "images");
            var fullPath = Path.Combine(uploads, testfile.FileName);
            testfile.CopyTo(new FileStream(fullPath, FileMode.Create));
            
            return Ok();
        }
        
        // POST: api/Event
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(PublicApi.v1.DTO.Event @event)
        {
            @event.AppUserId = User.GetUserId();
            
            await _bll.Events.AddAsync(PublicApi.v1.Mappers.EventMapper.MapFromExternal(@event));
            await _bll.SaveChangesAsync();
            // get the new id into the object
            return CreatedAtAction("GetEvent", new {id = @event.Id}, @event);
        }

        // DELETE: api/Event/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            // check for the ownership - is this Person record really belonging to logged in user.
            if (!await _bll.Events.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.Events.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
