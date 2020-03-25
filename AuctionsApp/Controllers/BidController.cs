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
    public class BidController : ControllerBase
    {
        private readonly BidManager _bm;

        public BidController(BidManager bm)
        {
            _bm = bm;
        }

        [HttpGet]
        public async Task<IEnumerable<FinalBid>> Get()
        {
            var data = await _bm.ListBids();
            return data;
        }

        [HttpGet("{aucID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<FinalBid>> Get(int aucID)
        {
            /*  var bid = await _bm.getBidOrNull(bidID);
              if (bid == null)
                  return NotFound();
              else return bid;*/
            var data = await _bm.SelectBids(aucID);
            return data;
        }

        [HttpPut("{bidID}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Modify([FromRoute] int bidID, [FromBody] FinalBid modositott)
        {
            if (bidID != modositott.ID)
                return BadRequest();

            var bid = await _bm.getBidOrNull(bidID);

            if (bid == null)
                return NotFound();

            else await _bm.modifyBid(bidID, modositott);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] FinalBid newBid)
        {

            await _bm.createBid(newBid);
            return CreatedAtAction(nameof(Get), new { }, new { });

        }

        [HttpDelete("{bidID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public async Task<ActionResult> Delete(int bidID)
        {
            var bid = await _bm.getBidOrNull(bidID);
            if (bid == null)
                return NotFound();
            else if (await _bm.TryTorolBid(bidID))
                return Ok();
            else return Conflict();
        }
    }
}
