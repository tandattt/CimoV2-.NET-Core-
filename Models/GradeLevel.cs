using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class GradeLevel
{
    public int Id { get; set; }

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public string? Name { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }

    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();
}
