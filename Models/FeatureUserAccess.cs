using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class FeatureUserAccess
{
    public int Id { get; set; }

    public byte[] RoleId { get; set; } = null!;

    public byte[] FeatureSettingId { get; set; } = null!;

    public ulong IsActive { get; set; }

    public virtual FeatureSetting FeatureSetting { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
