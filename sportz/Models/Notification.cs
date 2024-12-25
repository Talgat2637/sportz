using System;
using System.Collections.Generic;

namespace sportz.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int UserId { get; set; }

    public string Message { get; set; } = null!;

    public bool? IsRead { get; set; }

    public DateTime? SentDate { get; set; }

    public virtual User User { get; set; } = null!;
}
