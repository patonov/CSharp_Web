using System;
using System.Collections.Generic;

namespace WebAppOne.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int CategoryType { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
