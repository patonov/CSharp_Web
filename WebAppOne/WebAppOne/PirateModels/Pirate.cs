using System;
using System.Collections.Generic;

namespace WebAppOne.tralala;

public partial class Pirate
{
    public int Id { get; set; }

    public string Names { get; set; } = null!;

    public string? Pseudonym { get; set; }

    public DateOnly Birth { get; set; }

    public int? ShipId { get; set; }

    public string? BerthNumber { get; set; }

    public bool IsCaptain { get; set; }

    public decimal NetWealth { get; set; }

    public virtual Berth? BerthNumberNavigation { get; set; }

    public virtual Ship? Ship { get; set; }

    public virtual ICollection<Plunder> Plunders { get; set; } = new List<Plunder>();
}
