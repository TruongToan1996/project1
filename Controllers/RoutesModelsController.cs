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
    public class RoutesModelsController : ControllerBase
    {
        private readonly BusTicketReservationSystemContext _context;

        public RoutesModelsController(BusTicketReservationSystemContext context)
        {
            _context = context;
        }

        // GET: api/RoutesModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoutesModel>>> GetRoutesModels()
        {
          if (_context.RoutesModels == null)
          {
              return NotFound();
          }
            return await _context.RoutesModels.ToListAsync();
        }

        // GET: api/RoutesModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoutesModel>> GetRoutesModel(int id)
        {
          if (_context.RoutesModels == null)
          {
              return NotFound();
          }
            var routesModel = await _context.RoutesModels.FindAsync(id);

            if (routesModel == null)
            {
                return NotFound();
            }

            return routesModel;
        }

        // PUT: api/RoutesModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoutesModel(int id, RoutesModel routesModel)
        {
            if (id != routesModel.RouteId)
            {
                return BadRequest();
            }

            _context.Entry(routesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoutesModelExists(id))
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

        // POST: api/RoutesModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoutesModel>> PostRoutesModel(RoutesModel routesModel)
        {
          if (_context.RoutesModels == null)
          {
              return Problem("Entity set 'BusTicketReservationSystemContext.RoutesModels'  is null.");
          }
            _context.RoutesModels.Add(routesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoutesModel", new { id = routesModel.RouteId }, routesModel);
        }

        // DELETE: api/RoutesModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoutesModel(int id)
        {
            if (_context.RoutesModels == null)
            {
                return NotFound();
            }
            var routesModel = await _context.RoutesModels.FindAsync(id);
            if (routesModel == null)
            {
                return NotFound();
            }

            _context.RoutesModels.Remove(routesModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoutesModelExists(int id)
        {
            return (_context.RoutesModels?.Any(e => e.RouteId == id)).GetValueOrDefault();
        }
    }
}
