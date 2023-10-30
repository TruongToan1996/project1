using System;
using System.Collections.Generic;

namespace Aptech3.Models;

public partial class BusType
{
    public int BusTypeId { get; set; }

    public string? BusTypeName { get; set; }

    public string? Price { get; set; }

    public virtual ICollection<Bus> Buses { get; set; } = new List<Bus>();
}
