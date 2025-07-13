using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class Timetable
{
    public byte[] Id { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateOnly? StartDate { get; set; }

    public int? SubjectSlot { get; set; }

    public byte[] TeacherDetailUserId { get; set; } = null!;

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }

    public string? Weekday { get; set; }

    public byte[]? ClassroomId { get; set; } = null!;

    public byte[] SemesterId { get; set; } = null!;

    public byte[] SubjectId { get; set; } = null!;

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Semester Semester { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
