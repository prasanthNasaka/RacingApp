using System;
using System.Collections.Generic;

namespace infinitemoto.Models;

public partial class Payment
{
    public string Paymentid { get; set; } = null!;

    public string Accountid { get; set; } = null!;

    public string Subscriptionid { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public string Paymenttype { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime Paydate { get; set; }

    public string Status { get; set; } = null!;

    public string? Bankaccountid { get; set; }
}
