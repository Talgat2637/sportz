using System;
using System.Collections.Generic;

namespace sportz.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string AdminName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
