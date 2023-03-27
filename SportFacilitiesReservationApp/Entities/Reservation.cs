using System;
using System.Collections.Generic;

namespace SportFacilitiesReservationApp.Entities;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int UserId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public virtual ICollection<SportFacilityReservation> SportFacilityReservations { get; } = new List<SportFacilityReservation>();

    public virtual User User { get; set; } = null!;
}
