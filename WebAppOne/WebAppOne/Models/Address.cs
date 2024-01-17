using System;
using System.Collections.Generic;

namespace WebAppOne.Models;

public partial class Address
{
    public int Id { get; set; }

    public string StreetName { get; set; } = null!;

    public int StreetNumber { get; set; }

    public string PostCode { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
