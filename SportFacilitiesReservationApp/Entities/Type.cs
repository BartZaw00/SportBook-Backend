using System;
using System.Collections.Generic;

namespace SportFacilitiesReservationApp.Entities;

public partial class Type
{
    public int TypeId { get; set; }

    public string? Name { get; set; }

    public string? Surface { get; set; }

    public virtual ICollection<SportFacility> SportFacilities { get; } = new List<SportFacility>();
}
