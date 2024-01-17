using System;
using System.Collections.Generic;

namespace WebAppOne.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public int Number { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime DueDate { get; set; }

    public decimal Amount { get; set; }

    public int CurrencyType { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
