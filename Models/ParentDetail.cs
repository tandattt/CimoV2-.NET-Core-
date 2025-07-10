using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class ParentDetail
{
    public byte[] UserId { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public DateTime? CreateAt { get; set; }

    public byte[] CreateBy { get; set; } = null!;

    public string? Pin { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte[] UpdateBy { get; set; } = null!;

    public virtual ICollection<StudentOff> StudentOffs { get; set; } = new List<StudentOff>();

    public virtual ICollection<StudentParent> StudentParents { get; set; } = new List<StudentParent>();

    public virtual User User { get; set; } = null!;
}
