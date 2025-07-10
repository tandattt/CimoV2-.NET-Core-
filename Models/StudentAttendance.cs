using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class StudentAttendance
{
    public byte[] Id { get; set; } = null!;

    public string? CheckType { get; set; }

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public string? Session { get; set; }

    public byte[] TeacherDetailUserId { get; set; } = null!;

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }

    public byte[] StudentId { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
