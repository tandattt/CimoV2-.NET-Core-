using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class Notification
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public ulong? IsRead { get; set; }

    public string? Message { get; set; }

    public DateTime? ReadAt { get; set; }

    public string? Title { get; set; }

    public string? Type { get; set; }

    public byte[] UserId { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
