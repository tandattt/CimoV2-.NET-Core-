using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class ClassroomSubjectTeacher
{
    public byte[] Id { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }

    public byte[] AcademicYearsId { get; set; } = null!;

    public byte[] ClassroomId { get; set; } = null!;

    public byte[] SubjectId { get; set; } = null!;

    public byte[] TeacherDetailId { get; set; } = null!;

    public virtual AcademicYear AcademicYears { get; set; } = null!;

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual TeacherDetail TeacherDetail { get; set; } = null!;
}
