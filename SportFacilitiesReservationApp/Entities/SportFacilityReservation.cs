using System;
using System.Collections.Generic;

namespace SportFacilitiesReservationApp.Entities;

public partial class SportFacilityReservation
{
    public int SportFacilityId { get; set; }

    public int ReservationId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public virtual Reservation Reservation { get; set; } = null!;

    public virtual SportFacility SportFacility { get; set; } = null!;
}
