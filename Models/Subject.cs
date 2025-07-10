using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class Subject
{
    public byte[] Id { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public string? Name { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }

    public virtual ICollection<ClassroomSubjectTeacher> ClassroomSubjectTeachers { get; set; } = new List<ClassroomSubjectTeacher>();

    public virtual ICollection<StudentScore> StudentScores { get; set; } = new List<StudentScore>();

    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
