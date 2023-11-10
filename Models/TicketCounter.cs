using System;
using System.Collections.Generic;

namespace Aptech3.Models;

public  class TicketCounter
{
    public int CounterId { get; set; }

    public string? CounterName { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
