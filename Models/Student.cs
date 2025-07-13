using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class Student
{
    public byte[] Id { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public string? FirstName { get; set; }

    public string? FullName { get; set; }

    public string? LastName { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }
    public string? Gender { get; set; }

    public DateOnly? Birthday { get; set; }

    public virtual ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();

    public virtual ICollection<StudentClassroom> StudentClassrooms { get; set; } = new List<StudentClassroom>();

    public virtual ICollection<StudentOff> StudentOffs { get; set; } = new List<StudentOff>();

    public virtual ICollection<StudentParent> StudentParents { get; set; } = new List<StudentParent>();

    public virtual ICollection<StudentScore> StudentScores { get; set; } = new List<StudentScore>();
}
