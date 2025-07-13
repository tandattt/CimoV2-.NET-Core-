using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class Classroom
{
    public byte[]? Id { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public byte[] CreateBy { get; set; } = null!;

    public string? Name { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte[] UpdateBy { get; set; } = null!;

    public int GradeLevelId { get; set; }

    public virtual ICollection<ClassroomTeacherRole> ClassroomTeacherRoles { get; set; } = new List<ClassroomTeacherRole>();

    public virtual GradeLevel GradeLevel { get; set; } = null!;

    public virtual ICollection<StudentClassroom> StudentClassrooms { get; set; } = new List<StudentClassroom>();

    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
