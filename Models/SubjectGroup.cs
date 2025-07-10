using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class SubjectGroup
{
    public byte[] Id { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public string? Name { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }

    public virtual ICollection<TeacherDetail> TeacherDetails { get; set; } = new List<TeacherDetail>();
}
