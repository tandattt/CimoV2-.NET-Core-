using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class StudentParent
{
    public byte[] Id { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public DateTime? IsConfirmed { get; set; }

    public ulong? IsParentConfirmed { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }

    public byte[] ParentDetailUserId { get; set; } = null!;

    public byte[] StudentId { get; set; } = null!;

    public virtual ParentDetail ParentDetailUser { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
