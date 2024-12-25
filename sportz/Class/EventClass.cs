using Microsoft.AspNetCore.Identity;
using sportz.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace sportz.Class
{
    public record EventClassRequest(
        [NotNull]
        [Length(1, 200)]
        string EventName,
        [NotNull]
        [Length(1, 100)]
        DateTime EventDate,
        [NotNull]
        [Length(1, 100)]
        int VenueID,
        [NotNull]
        [Length(1, 100)]
        string SportType,
        [NotNull]
        [Length(1, 100)]
        string Description
    )
    {
    }
}
