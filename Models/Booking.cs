using System;
using System.Collections.Generic;

namespace project1.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? BusId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? BookingDate { get; set; }

    public DateTime? DepartureDate { get; set; }

    public int? SeatNumber { get; set; }

    public string? PaymentStatus { get; set; }

    public string? Status { get; set; }

    public virtual Customer? Customer { get; set; }
}
