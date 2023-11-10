using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aptech3.Data;
using Aptech3.Models.Buses;

namespace Aptech3.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BusTypesController : ControllerBase
    {
        private readonly Aptech3Context _context;

        public BusTypesController(Aptech3Context context)
        {
            _context = context;
        }

        // GET: api/BusTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusType>>> GetBusTypes()
        {
          if (_context.BusTypes == null)
          {
              return NotFound();
          }
            return await _context.BusTypes.ToListAsync();
        }

        // GET: api/BusTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusType>> GetBusType(int id)
        {
          if (_context.BusTypes == null)
          {
              return NotFound();
          }
            var busType = await _context.BusTypes.FindAsync(id);

            if (busType == null)
            {
                return NotFound();
            }

            return busType;
        }

        // PUT: api/BusTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusType(int id, BusType busType)
        {
            if (id != busType.BusTypeId)
            {
                return BadRequest();
            }

            _context.Entry(busType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusTypeExists(id))
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

        // POST: api/BusTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusType>> PostBusType(BusType busType)
        {
          if (_context.BusTypes == null)
          {
              return Problem("Entity set 'Aptech3Context.BusTypes'  is null.");
          }
            _context.BusTypes.Add(busType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BusTypeExists(busType.BusTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBusType", new { id = busType.BusTypeId }, busType);
        }

        // DELETE: api/BusTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusType(int id)
        {
            if (_context.BusTypes == null)
            {
                return NotFound();
            }
            var busType = await _context.BusTypes.FindAsync(id);
            if (busType == null)
            {
                return NotFound();
            }

            _context.BusTypes.Remove(busType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusTypeExists(int id)
        {
            return (_context.BusTypes?.Any(e => e.BusTypeId == id)).GetValueOrDefault();
        }
    }
}
