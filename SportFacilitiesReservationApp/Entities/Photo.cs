using System;
using System.Collections.Generic;

namespace SportFacilitiesReservationApp.Entities;

public partial class Photo
{
    public int PhotoId { get; set; }

    public int SportFacilityId { get; set; }

    public string PhotoUrl { get; set; } = null!;

    public virtual SportFacility SportFacility { get; set; } = null!;
}
