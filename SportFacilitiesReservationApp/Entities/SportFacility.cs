using System;
using System.Collections.Generic;

namespace SportFacilitiesReservationApp.Entities;

public partial class SportFacility
{
    public int SportFacilityId { get; set; }

    public int SportId { get; set; }

    public int TypeId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public TimeSpan? OpenTime { get; set; }

    public TimeSpan? CloseTime { get; set; }

    public virtual ICollection<Photo> Photos { get; } = new List<Photo>();

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();

    public virtual Sport Sport { get; set; } = null!;

    public virtual ICollection<SportFacilityReservation> SportFacilityReservations { get; } = new List<SportFacilityReservation>();

    public virtual Type Type { get; set; } = null!;
}
