using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class StudentOff
{
    public byte[] Id { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Reason { get; set; }

    public string? ReasonRejected { get; set; }

    public DateOnly? StartDate { get; set; }

    public string? Status { get; set; }

    public byte[] TeacherDetailUserId { get; set; } = null!;

    public DateTime? UpdateAt { get; set; }

    public byte[] UpdateBy { get; set; } = null!;

    public byte[] ParentDetailUserId { get; set; } = null!;

    public byte[] StudentId { get; set; } = null!;

    public virtual ParentDetail ParentDetailUser { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
