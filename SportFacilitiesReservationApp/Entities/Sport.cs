using System;
using System.Collections.Generic;

namespace SportFacilitiesReservationApp.Entities;

public partial class Sport
{
    public int SportId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<SportFacility> SportFacilities { get; } = new List<SportFacility>();
}
