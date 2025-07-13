using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class StudentScore
{
    public byte[] Id { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public byte[] CreateBy { get; set; } = null!;

    public float? Score { get; set; }

    public int? ScoreIndex { get; set; }

    public string? ScoreType { get; set; }

    public byte[] ScoreTypeId { get; set; } = null!;

    public byte[] TeacherDetailUserId { get; set; } = null!;

    public DateTime? UpdateAt { get; set; }

    public byte[] UpdateBy { get; set; } = null!;

    public byte[]? AcademicYearsId { get; set; } = null!;

    public byte[] SemesterId { get; set; } = null!;

    public byte[] StudentId { get; set; } = null!;

    public byte[] SubjectId { get; set; } = null!;

    public virtual AcademicYear AcademicYears { get; set; } = null!;

    public virtual Semester Semester { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
