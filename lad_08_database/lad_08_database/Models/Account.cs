using System;
using System.Collections.Generic;

namespace lad_08_database.Models;

public partial class Account
{
    public Guid AccountId { get; set; }

    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Picture { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public bool? IsAdmin { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();
}
