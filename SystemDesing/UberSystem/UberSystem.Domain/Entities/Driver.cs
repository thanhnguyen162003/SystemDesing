using System;
using System.Collections.Generic;

namespace UberSystem.Domain.Entities;

public partial class Driver
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public long? CabId { get; set; }

    public string? Email { get; set; }

    public DateTime? Dob { get; set; }

    public double? LocationLatitude { get; set; }

    public double? LocationLongitude { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public virtual Cab? Cab { get; set; }

    public virtual ICollection<Cab> Cabs { get; } = new List<Cab>();

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    public virtual ICollection<Trip> Trips { get; } = new List<Trip>();
}
