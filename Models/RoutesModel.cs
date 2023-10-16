using System;
using System.Collections.Generic;

namespace project1.Models;

public partial class RoutesModel
{
    public int RouteId { get; set; }

    public string? RouteName { get; set; }

    public string? StartingPoint { get; set; }

    public string? DestinationPoint { get; set; }

    public int? DistanceInKm { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Bus> Buses { get; set; } = new List<Bus>();

    public virtual ICollection<RouteLocation> RouteLocations { get; set; } = new List<RouteLocation>();
}
