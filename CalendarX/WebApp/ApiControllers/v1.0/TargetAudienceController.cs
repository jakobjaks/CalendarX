using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1._0
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TargetAudienceController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public TargetAudienceController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/TargetAudience
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.TargetAudience>>> GetTargetAudiences()
        {
            return (await _bll.TargetAudiences.AllAsync())
                .Select(e => PublicApi.v1.Mappers.TargetAudienceMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/TargetAudience/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.TargetAudience>> GetTargetAudience(int id)
        {
            var targetAudience = PublicApi.v1.Mappers.TargetAudienceMapper.MapFromBLL(await _bll.TargetAudiences.FindAsync(id));

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
        public async Task<IActionResult> PutTargetAudience(int id, PublicApi.v1.DTO.TargetAudience targetAudience)
        {
            if (id != targetAudience.Id)
            {
                return BadRequest();
            }
            if (await _bll.TargetAudiences.FindAsync(id) == null)
            {
                return NotFound();
            }
            _bll.TargetAudiences.Update(PublicApi.v1.Mappers.TargetAudienceMapper.MapFromExternal(targetAudience));
            await _bll.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/TargetAudience
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TargetAudience>> PostTargetAudience(PublicApi.v1.DTO.TargetAudience targetAudience)
        {
            
            targetAudience = PublicApi.v1.Mappers.TargetAudienceMapper.MapFromBLL(
                _bll.TargetAudiences.Add(PublicApi.v1.Mappers.TargetAudienceMapper.MapFromExternal(targetAudience)));
            await _bll.SaveChangesAsync();

            // get the new id into the object

            return CreatedAtAction("GetTargetAudience", new {id = targetAudience.Id}, targetAudience);
        }

        // DELETE: api/TargetAudience/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTargetAudience(int id)
        {
            if (await _bll.TargetAudiences.FindAsync(id) == null)
            {
                return NotFound();
            }
            _bll.TargetAudiences.Remove(id);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

    }
}
