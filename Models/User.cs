using System;
using System.Collections.Generic;

namespace Aptech3.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Qualification { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? UserCode { get; set; }

    public string? Role { get; set; }

    public int? CounterId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual TicketCounter? Counter { get; set; }
}
