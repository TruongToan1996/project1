using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aptech3.Data;
using Aptech3.Models;
using Microsoft.AspNetCore.Identity;
using Aptech3.Models.Bookings;

namespace Aptech3.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly Aptech3Context _context;
        private readonly UserManager<User> _userManager;

        public BookingsController(Aptech3Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            if (_context.Bookings == null)
            {
                return NotFound();
            }
            return await _context.Bookings.ToListAsync();
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            if (_context.Bookings == null)
            {
                return NotFound();
            }
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, BookingInput input)
        {

            var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.BookingId == id);
            var user = await _userManager.FindByIdAsync(input.UserId);
            // check neu co use != null thi gan no
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == input.CustomerId);
            // check neu co use != null thi gan no
            var bus = await _context.Buses.FirstOrDefaultAsync(x => x.BusId == input.BusId);
            if (booking == null)
            {
                return BadRequest();
            }


            booking.BookingDate = input.BookingDate;
            booking.TravelDate = input.TravelDate;
            booking.NumberOfSeats = input.NumberOfSeats;
            booking.TotalPrice = input.TotalPrice;
            booking.PaymentStatus = input.PaymentStatus;
            booking.Status = input.Status;
            booking.Description = input.Description;

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(BookingInput input)
        {
            if (_context.Bookings == null)
            {
                return Problem("Entity set 'Aptech3Context.Bookings'  is null.");
            }
            var user = await _userManager.FindByIdAsync(input.UserId);

            // check neu co use != null thi gan no
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == input.CustomerId);
            // check neu co use != null thi gan no
            var bus = await _context.Buses.FirstOrDefaultAsync(x => x.BusId == input.BusId);


            var booking = new Booking()
            {
                User = user,
                Customer = customer,
                BookingDate = input.BookingDate,
                TravelDate = input.TravelDate,
                NumberOfSeats = input.NumberOfSeats,
                TotalPrice = input.TotalPrice,
                PaymentStatus = input.PaymentStatus,
                Status = input.Status,
                Description = input.Description,

            };
            _context.Bookings.Add(booking);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingExists(booking.BookingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBooking", new { id = booking.BookingId }, booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            if (_context.Bookings == null)
            {
                return NotFound();
            }
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingExists(int id)
        {
            return (_context.Bookings?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
