using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class StudentClassroom
{
    public byte[] Id { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public ulong? IsCurrent { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }

    public byte[] AcademicYearsId { get; set; } = null!;

    public byte[] ClassroomId { get; set; } = null!;

    public byte[] StudentId { get; set; } = null!;

    public virtual AcademicYear AcademicYears { get; set; } = null!;

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
