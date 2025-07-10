using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class FeatureSetting
{
    public byte[] Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<FeatureUserAccess> FeatureUserAccesses { get; set; } = new List<FeatureUserAccess>();
}
