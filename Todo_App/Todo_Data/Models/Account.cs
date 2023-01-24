using System;
using System.Collections.Generic;

namespace Todo_Data.Models;

public partial class Account
{
    public int AccId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? Status { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateVerified { get; set; }

    public DateTime? DateClosed { get; set; }
}
