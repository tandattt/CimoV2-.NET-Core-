using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class PostComment
{
    public byte[] Id { get; set; } = null!;

    public string? Content { get; set; }

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public int? ParentCommentId { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }

    public byte[] PostId { get; set; } = null!;

    public byte[] UserId { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
