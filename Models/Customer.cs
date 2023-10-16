using System;
using System.Collections.Generic;

namespace project1.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
