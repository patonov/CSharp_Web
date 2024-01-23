using System;
using System.Collections.Generic;

namespace WebAppOne.tralala;

public partial class Berth
{
    public string Number { get; set; } = null!;

    public string Category { get; set; } = null!;

    public int? ShipId { get; set; }

    public virtual Pirate? Pirate { get; set; }

    public virtual Ship? Ship { get; set; }
}
