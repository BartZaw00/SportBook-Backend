using System;
using System.Collections.Generic;

namespace SportFacilitiesReservationApp.Entities;

public partial class Role
{
    public int RoleId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
