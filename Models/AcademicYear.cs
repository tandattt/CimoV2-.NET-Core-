using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class AcademicYear
{
    public byte[] Id { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Name { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }

    public virtual ICollection<ClassroomHomeroomTeacher> ClassroomHomeroomTeachers { get; set; } = new List<ClassroomHomeroomTeacher>();

    public virtual ICollection<ClassroomSubjectTeacher> ClassroomSubjectTeachers { get; set; } = new List<ClassroomSubjectTeacher>();

    public virtual ICollection<Semester> Semesters { get; set; } = new List<Semester>();

    public virtual ICollection<StudentClassroom> StudentClassrooms { get; set; } = new List<StudentClassroom>();

    public virtual ICollection<StudentScore> StudentScores { get; set; } = new List<StudentScore>();
}
