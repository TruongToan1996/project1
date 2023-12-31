﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aptech3.Data;
using Aptech3.Models.Buses;
using Microsoft.AspNetCore.Identity;
using Aptech3.Models.Bookings;
using Aptech3.Models.Customers;
using Aptech3.Models;

namespace Aptech3.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private readonly Aptech3Context _context;

        public BusesController(Aptech3Context context)
        {
            _context = context;
        }

        // GET: api/Buses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bus>>> GetBuses()
        {
          if (_context.Buses == null)
          {
              return NotFound();
          }
            return await _context.Buses.ToListAsync();
        }

        // GET: api/Buses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bus>> GetBus(int id)
        {
          if (_context.Buses == null)
          {
              return NotFound();
          }
            var bus = await _context.Buses.FindAsync(id);

            if (bus == null)
            {
                return NotFound();
            }

            return bus;
        }

        // PUT: api/Buses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBus(int id, Bus bus)
        {
            if (id != bus.BusId)
            {
                return BadRequest();
            }

            _context.Entry(bus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusExists(id))
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

        // POST: api/Buses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bus>> PostBus(BusInput input)
        {
          if (_context.Buses == null)
          {
              return Problem("Entity set 'Aptech3Context.Buses'  is null.");
          }
            var bustype = await _context.Buses.FirstOrDefaultAsync(x => x.BusTypeId == input.BusTypeId);
            var router = await _context.BusRoutes.FirstOrDefaultAsync(x => x.BusRouteId == input.RouteId);
            
            var bus = new Bus()
            {
                BusName = input.BusName,
                TotalSeats = input.TotalSeats,
                DepartureTime = input.DepartureTime,
                AvailableSeats = input.AvailableSeats,
                Description = input.Description,
            };
            _context.Buses.Add(bus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BusExists(bus.BusId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBus", new { id = bus.BusId }, bus);
        }

        // DELETE: api/Buses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBus(int id)
        {
            if (_context.Buses == null)
            {
                return NotFound();
            }
            var bus = await _context.Buses.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }

            _context.Buses.Remove(bus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusExists(int id)
        {
            return (_context.Buses?.Any(e => e.BusId == id)).GetValueOrDefault();
        }
    }
}
