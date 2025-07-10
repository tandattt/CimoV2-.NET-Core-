using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class Semester
{
    public byte[] Id { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Name { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }

    public byte[] AcademicYearsId { get; set; } = null!;

    public virtual AcademicYear AcademicYears { get; set; } = null!;

    public virtual ICollection<StudentScore> StudentScores { get; set; } = new List<StudentScore>();

    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
