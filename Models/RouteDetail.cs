using System;
using System.Collections.Generic;
using Aptech3.Models.Buses;

namespace Aptech3.Models;

public partial class RouteDetail
{
    public int RouteDetailId { get; set; }

    public int? BusRouteId { get; set; }

    public string? StartingPoint { get; set; }

    public string? DestinationPoint { get; set; }

    public double? Distance { get; set; }

    public virtual BusRoute? BusRoute { get; set; }
}
