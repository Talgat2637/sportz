using Microsoft.AspNetCore.Identity;
using sportz.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace sportz.Class
{
    public record AdminsClassRequest(
        [NotNull]
        [Length(1, 100)]
        string AdminName,
        [NotNull]
        [Length(1, 100)]
        string Email,
        [NotNull]
        [Length(1, 200)]
        string PasswordHash,
        [NotNull]
        [Length(1, 100)]
        int UserID
    )
    {
    }
}
