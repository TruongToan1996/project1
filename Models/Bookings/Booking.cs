using System;
using System.Collections.Generic;
using Aptech3.Models.Buses;
using Aptech3.Models.Customers;

namespace Aptech3.Models.Bookings;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? CustomerId { get; set; }

    public string UserId { get; set; }

    public int? BusId { get; set; }

    public DateTime? BookingDate { get; set; }

    public DateTime? TravelDate { get; set; }

    public int? NumberOfSeats { get; set; }

    public int? TotalPrice { get; set; }

    public string? PaymentStatus { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public virtual Bus? Bus { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual User? User { get; set; }
}
