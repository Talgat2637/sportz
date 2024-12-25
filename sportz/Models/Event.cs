using System;
using System.Collections.Generic;

namespace sportz.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string EventName { get; set; } = null!;

    public DateOnly EventDate { get; set; }

    public int VenueId { get; set; }

    public string SportType { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Venue Venue { get; set; } = null!;
}
