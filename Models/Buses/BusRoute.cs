using System;
using System.Collections.Generic;

namespace Aptech3.Models.Buses;

public class BusRoute
{
    public int BusRouteId { get; set; }

    public string? BusRouteName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Bus> Buses { get; set; } = new List<Bus>();

    public virtual ICollection<RouteDetail> RouteDetails { get; set; } = new List<RouteDetail>();
}
