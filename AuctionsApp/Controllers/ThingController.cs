using AuctionsApp.BL;
using AuctionsApp.DAL;
using AuctionsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AuctionsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingController : ControllerBase
    {
        private readonly ThingManager _tm;
        

        public ThingController(ThingManager tm)
        {
            _tm = tm;  
        }

        [HttpGet]
        public async Task<IEnumerable<FinalThing>> Get()
        {
            var data= await _tm.ListThings();
            return data;
        }

        [HttpGet("{thingID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<FinalThing>> Get(int thingID)
        {
            var thing = await _tm.getThingOrNull(thingID);
            if (thing == null)
                return NotFound();
            else return thing;
           
        }

        [HttpPut("{thingID}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Modify([FromRoute] int thingID, [FromBody] FinalThing modositott)
        {
            if (thingID != modositott.ID)
                return BadRequest();

            var thing = await _tm.getThingOrNull(thingID);

            if (thing == null)
                return NotFound();

            else await _tm.modifyThing(thingID, modositott);

            return NoContent(); 
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] FinalThing newThing)
        {
           
            await _tm.createThing(newThing);
            return CreatedAtAction(nameof(Get), new { },new { });

        }

        [HttpDelete("{thingID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public async Task<ActionResult> Delete(int thingID)
        {
            var thing = await  _tm.getThingOrNull(thingID);
            if (thing == null)
                return NotFound();
            else if (await _tm.TryTorolThing(thingID))
                return Ok();
            else return Conflict();
        }

    }
}
