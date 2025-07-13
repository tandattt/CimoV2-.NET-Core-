using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class ClassroomSubjectTeacher
{
    public byte[] Id { get; set; } = null!;
    public byte[] ClassroomTeacherRoleId { get; set; } = null!;
    public byte[] SubjectId { get; set; } = null!;
    public DateTime? CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public byte[]? CreateBy { get; set; }
    public byte[]? UpdateBy { get; set; }

    // Navigation properties
    public virtual ClassroomTeacherRole ClassroomTeacherRole { get; set; } = null!;
    public virtual Subject Subject { get; set; } = null!;
}
