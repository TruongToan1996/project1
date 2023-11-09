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
    public class RouteDetailsController : ControllerBase
    {
        private readonly Aptech3Context _context;

        public RouteDetailsController(Aptech3Context context)
        {
            _context = context;
        }

        // GET: api/RouteDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteDetail>>> GetRouteDetails()
        {
          if (_context.RouteDetails == null)
          {
              return NotFound();
          }
            return await _context.RouteDetails.ToListAsync();
        }

        // GET: api/RouteDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RouteDetail>> GetRouteDetail(int id)
        {
          if (_context.RouteDetails == null)
          {
              return NotFound();
          }
            var routeDetail = await _context.RouteDetails.FindAsync(id);

            if (routeDetail == null)
            {
                return NotFound();
            }

            return routeDetail;
        }

        // PUT: api/RouteDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRouteDetail(int id, RouteDetail routeDetail)
        {
            if (id != routeDetail.RouteDetailId)
            {
                return BadRequest();
            }

            _context.Entry(routeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteDetailExists(id))
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

        // POST: api/RouteDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RouteDetail>> PostRouteDetail(RouteDetail routeDetail)
        {
          if (_context.RouteDetails == null)
          {
              return Problem("Entity set 'Aptech3Context.RouteDetails'  is null.");
          }
            _context.RouteDetails.Add(routeDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RouteDetailExists(routeDetail.RouteDetailId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRouteDetail", new { id = routeDetail.RouteDetailId }, routeDetail);
        }

        // DELETE: api/RouteDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRouteDetail(int id)
        {
            if (_context.RouteDetails == null)
            {
                return NotFound();
            }
            var routeDetail = await _context.RouteDetails.FindAsync(id);
            if (routeDetail == null)
            {
                return NotFound();
            }

            _context.RouteDetails.Remove(routeDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RouteDetailExists(int id)
        {
            return (_context.RouteDetails?.Any(e => e.RouteDetailId == id)).GetValueOrDefault();
        }
    }
}
