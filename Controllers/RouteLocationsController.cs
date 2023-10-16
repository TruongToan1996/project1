using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project1;
using project1.Models;

namespace project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteLocationsController : ControllerBase
    {
        private readonly BusTicketReservationSystemContext _context;

        public RouteLocationsController(BusTicketReservationSystemContext context)
        {
            _context = context;
        }

        // GET: api/RouteLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteLocation>>> GetRouteLocations()
        {
          if (_context.RouteLocations == null)
          {
              return NotFound();
          }
            return await _context.RouteLocations.ToListAsync();
        }

        // GET: api/RouteLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RouteLocation>> GetRouteLocation(int id)
        {
          if (_context.RouteLocations == null)
          {
              return NotFound();
          }
            var routeLocation = await _context.RouteLocations.FindAsync(id);

            if (routeLocation == null)
            {
                return NotFound();
            }

            return routeLocation;
        }

        // PUT: api/RouteLocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRouteLocation(int id, RouteLocation routeLocation)
        {
            if (id != routeLocation.LocationId)
            {
                return BadRequest();
            }

            _context.Entry(routeLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteLocationExists(id))
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

        // POST: api/RouteLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RouteLocation>> PostRouteLocation(RouteLocation routeLocation)
        {
          if (_context.RouteLocations == null)
          {
              return Problem("Entity set 'BusTicketReservationSystemContext.RouteLocations'  is null.");
          }
            _context.RouteLocations.Add(routeLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRouteLocation", new { id = routeLocation.LocationId }, routeLocation);
        }

        // DELETE: api/RouteLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRouteLocation(int id)
        {
            if (_context.RouteLocations == null)
            {
                return NotFound();
            }
            var routeLocation = await _context.RouteLocations.FindAsync(id);
            if (routeLocation == null)
            {
                return NotFound();
            }

            _context.RouteLocations.Remove(routeLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RouteLocationExists(int id)
        {
            return (_context.RouteLocations?.Any(e => e.LocationId == id)).GetValueOrDefault();
        }
    }
}
