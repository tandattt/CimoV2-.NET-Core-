using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class Role
{
    public byte[] Id { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }

    public virtual ICollection<ClassroomTeacherRole> ClassroomTeacherRoles { get; set; } = new List<ClassroomTeacherRole>();

    public virtual ICollection<FeatureUserAccess> FeatureUserAccesses { get; set; } = new List<FeatureUserAccess>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
