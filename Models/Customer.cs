using System;
using System.Collections.Generic;

namespace Aptech3.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? AgeGroupId { get; set; }

    public virtual AgeGroup? AgeGroup { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
