using System;
using System.Collections.Generic;

namespace SportFacilitiesReservationApp.Entities;

public partial class User
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string? Username { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? PhotoUrl { get; set; }

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();

    public virtual Role Role { get; set; } = null!;
}
