using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class Post
{
    public byte[] Id { get; set; } = null!;

    public string? Content { get; set; }

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public byte[]? ToClass { get; set; }

    public int? TotalComment { get; set; }

    public int? TotalLike { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }

    public string? Visibility { get; set; }

    public byte[] UserId { get; set; } = null!;

    public virtual ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();

    public virtual ICollection<PostImage> PostImages { get; set; } = new List<PostImage>();

    public virtual ICollection<PostLike> PostLikes { get; set; } = new List<PostLike>();

    public virtual User User { get; set; } = null!;
}
