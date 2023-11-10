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
    public class BusRoutesController : ControllerBase
    {
        private readonly Aptech3Context _context;

        public BusRoutesController(Aptech3Context context)
        {
            _context = context;
        }

        // GET: api/BusRoutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusRoute>>> GetBusRoutes()
        {
          if (_context.BusRoutes == null)
          {
              return NotFound();
          }
            return await _context.BusRoutes.ToListAsync();
        }

        // GET: api/BusRoutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusRoute>> GetBusRoute(int id)
        {
          if (_context.BusRoutes == null)
          {
              return NotFound();
          }
            var busRoute = await _context.BusRoutes.FindAsync(id);

            if (busRoute == null)
            {
                return NotFound();
            }

            return busRoute;
        }

        // PUT: api/BusRoutes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusRoute(int id, BusRoute busRoute)
        {
            if (id != busRoute.BusRouteId)
            {
                return BadRequest();
            }

            _context.Entry(busRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusRouteExists(id))
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

        // POST: api/BusRoutes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusRoute>> PostBusRoute(BusRoute busRoute)
        {
          if (_context.BusRoutes == null)
          {
              return Problem("Entity set 'Aptech3Context.BusRoutes'  is null.");
          }
            _context.BusRoutes.Add(busRoute);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BusRouteExists(busRoute.BusRouteId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBusRoute", new { id = busRoute.BusRouteId }, busRoute);
        }

        // DELETE: api/BusRoutes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusRoute(int id)
        {
            if (_context.BusRoutes == null)
            {
                return NotFound();
            }
            var busRoute = await _context.BusRoutes.FindAsync(id);
            if (busRoute == null)
            {
                return NotFound();
            }

            _context.BusRoutes.Remove(busRoute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusRouteExists(int id)
        {
            return (_context.BusRoutes?.Any(e => e.BusRouteId == id)).GetValueOrDefault();
        }
    }
}
