using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aptech3.Data;
using Aptech3.Models;

namespace Aptech3.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class TicketCountersController : ControllerBase
    {
        private readonly Aptech3Context _context;

        public TicketCountersController(Aptech3Context context)
        {
            _context = context;
        }

        // GET: api/TicketCounters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketCounter>>> GetTicketCounters()
        {
          if (_context.TicketCounters == null)
          {
              return NotFound();
          }
            return await _context.TicketCounters.ToListAsync();
        }

        // GET: api/TicketCounters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketCounter>> GetTicketCounter(int id)
        {
          if (_context.TicketCounters == null)
          {
              return NotFound();
          }
            var ticketCounter = await _context.TicketCounters.FindAsync(id);

            if (ticketCounter == null)
            {
                return NotFound();
            }

            return ticketCounter;
        }

        // PUT: api/TicketCounters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketCounter(int id, TicketCounter ticketCounter)
        {
            if (id != ticketCounter.CounterId)
            {
                return BadRequest();
            }

            _context.Entry(ticketCounter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketCounterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TicketCounters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TicketCounter>> PostTicketCounter(TicketCounter ticketCounter)
        {
          if (_context.TicketCounters == null)
          {
              return Problem("Entity set 'Aptech3Context.TicketCounters'  is null.");
          }
            _context.TicketCounters.Add(ticketCounter);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TicketCounterExists(ticketCounter.CounterId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTicketCounter", new { id = ticketCounter.CounterId }, ticketCounter);
        }

        // DELETE: api/TicketCounters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketCounter(int id)
        {
            if (_context.TicketCounters == null)
            {
                return NotFound();
            }
            var ticketCounter = await _context.TicketCounters.FindAsync(id);
            if (ticketCounter == null)
            {
                return NotFound();
            }

            _context.TicketCounters.Remove(ticketCounter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketCounterExists(int id)
        {
            return (_context.TicketCounters?.Any(e => e.CounterId == id)).GetValueOrDefault();
        }
    }
}
