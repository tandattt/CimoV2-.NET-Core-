using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class UserRole
{
    public byte[] Id { get; set; } = null!;

    public byte[] RoleId { get; set; } = null!;

    public byte[] UserId { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
