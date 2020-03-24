using AuctionsApp.BL;
using AuctionsApp.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly AuctionManager _am;


        public AuctionController(AuctionManager am)
        {
            _am = am;
        }

        [HttpGet]
        public async Task<IEnumerable<FinalAuction>> Get()
        {
            var data = await _am.ListAuctions();
            return data;
        }

        [HttpGet("{aucID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<FinalAuction>> Get(int aucID)
        {
            var auc = await _am.getAuctionOrNull(aucID);
            if (auc == null)
                return NotFound();
            else return auc;

        }

        [HttpPut("{aucID}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Modify([FromRoute] int aucID, [FromBody] FinalAuction modositott)
        {
            if (aucID != modositott.ID)
                return BadRequest();

            var auc = await _am.getAuctionOrNull(aucID);

            if (auc == null)
                return NotFound();

            else await _am.modifyAuction(aucID, modositott);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] FinalAuction newThing)
        {

            await _am.createAuction(newThing);
            return CreatedAtAction(nameof(Get), new { }, new { });

        }

        [HttpDelete("{aucID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public async Task<ActionResult> Delete(int aucID)
        {
            var thing = await _am.getAuctionOrNull(aucID);
            if (thing == null)
                return NotFound();
            else if (await _am.TryTorolAuction(aucID))
                return Ok();
            else return Conflict();
        }
    }
}
