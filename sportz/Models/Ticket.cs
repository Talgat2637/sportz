using System;
using System.Collections.Generic;

namespace sportz.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int EventId { get; set; }

    public decimal Price { get; set; }

    public string SeatNumber { get; set; } = null!;

    public bool? IsAvailable { get; set; }

    public virtual ICollection<OrderTicket> OrderTickets { get; set; } = new List<OrderTicket>();
}
