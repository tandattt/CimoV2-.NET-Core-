using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class ClassroomTeacherRole
{
    public byte[] Id { get; set; } = null!;

    public byte[] TeacherDetail { get; set; } = null!;

    public byte[] ClassroomId { get; set; } = null!;

    public byte[] AcademicYear { get; set; } = null!;

    public byte[] RoleId { get; set; } = null!;

    public virtual AcademicYear AcademicYearNavigation { get; set; } = null!;

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;

    public virtual TeacherDetail TeacherDetailNavigation { get; set; } = null!;
}
