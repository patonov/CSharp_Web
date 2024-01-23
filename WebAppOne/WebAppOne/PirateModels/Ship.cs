using System;
using System.Collections.Generic;

namespace WebAppOne.tralala;

public partial class Ship
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public DateOnly Constructed { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Berth> Berths { get; set; } = new List<Berth>();

    public virtual ICollection<Pirate> Pirates { get; set; } = new List<Pirate>();
}
