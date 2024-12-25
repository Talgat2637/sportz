using System;
using System.Collections.Generic;

namespace sportz.Models;

public partial class Favorite
{
    public int FavoriteId { get; set; }

    public int UserId { get; set; }

    public int EventId { get; set; }

    public DateTime? AddedDate { get; set; }

    public virtual User User { get; set; } = null!;
}
