using System;
using System.Collections.Generic;

namespace sportz.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public virtual ICollection<OrderTicket> OrderTickets { get; set; } = new List<OrderTicket>();

    public virtual User User { get; set; } = null!;
}
