using System;
using System.Collections.Generic;
using Aptech3.Models;

namespace Aptech3;

public partial class AgeGroup
{
    public int AgeGroupId { get; set; }

    public string? AgeGroup1 { get; set; }

    public double? Benefit { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
