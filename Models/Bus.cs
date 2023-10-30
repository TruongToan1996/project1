using System;
using System.Collections.Generic;

namespace Aptech3.Models;

public partial class Bus
{
    public int BusId { get; set; }

    public string? BusName { get; set; }

    public int? BusTypeId { get; set; }

    public int? TotalSeats { get; set; }

    public int? RouteId { get; set; }

    public TimeSpan? DepartureTime { get; set; }

    public int? AvailableSeats { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual BusType? BusType { get; set; }

    public virtual BusRoute? Route { get; set; }
}
