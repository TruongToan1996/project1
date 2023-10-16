using System;
using System.Collections.Generic;

namespace project1.Models;

public partial class RouteLocation
{
    public int LocationId { get; set; }

    public int? RouteId { get; set; }

    public string? LocationName { get; set; }

    public int? LocationOrder { get; set; }

    public virtual RoutesModel? Route { get; set; }
}
