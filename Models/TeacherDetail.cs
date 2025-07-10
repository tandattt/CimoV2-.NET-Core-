using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class TeacherDetail
{
    public byte[] UserId { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }

    public byte[] AcademicLevelId { get; set; } = null!;

    public byte[] SubjectGroupId { get; set; } = null!;

    public virtual AcademicLevel AcademicLevel { get; set; } = null!;

    public virtual ICollection<ClassroomSubjectTeacher> ClassroomSubjectTeachers { get; set; } = new List<ClassroomSubjectTeacher>();

    public virtual ICollection<ClassroomTeacherRole> ClassroomTeacherRoles { get; set; } = new List<ClassroomTeacherRole>();

    public virtual SubjectGroup SubjectGroup { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
