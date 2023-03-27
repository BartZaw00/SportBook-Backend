using System;
using System.Collections.Generic;

namespace SportFacilitiesReservationApp.Entities;

public partial class Review
{
    public int ReviewId { get; set; }

    public int SportFacilityId { get; set; }

    public int UserId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public virtual SportFacility SportFacility { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
