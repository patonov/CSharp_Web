using System;
using System.Collections.Generic;

namespace WebAppOne.tralala;

public partial class Plunder
{
    public int Id { get; set; }

    public string Location { get; set; } = null!;

    public string Spoils { get; set; } = null!;

    public decimal Value { get; set; }

    public bool IsDone { get; set; }

    public virtual ICollection<Pirate> Pirates { get; set; } = new List<Pirate>();
}
