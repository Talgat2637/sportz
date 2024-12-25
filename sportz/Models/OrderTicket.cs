using System;
using System.Collections.Generic;

namespace sportz.Models;

public partial class OrderTicket
{
    public int OrderTicketId { get; set; }

    public int OrderId { get; set; }

    public int TicketId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;
}
