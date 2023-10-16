using System;
using System.Collections.Generic;

namespace project1.Models;

public partial class Bus
{
    public int BusId { get; set; }

    public string? BusName { get; set; }

    public string? BusType { get; set; }

    public int? RouteId { get; set; }

    public TimeSpan? DepartureTime { get; set; }

    public int? TotalSeats { get; set; }

    public int? AvailableSeats { get; set; }

    public string? Description { get; set; }

    public virtual RoutesModel? Route { get; set; }
}
