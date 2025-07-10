using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class User
{
    public byte[] Id { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public DateTime? CreateAt { get; set; }

    public byte[]? CreateBy { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? FullName { get; set; }

    public bool? IsDeleted { get; set; }

    public string? LastName { get; set; }

    public string? Password { get; set; }

    public string? PhoneNumber { get; set; }

    public sbyte? Status { get; set; }

    public DateTime? UpdateAt { get; set; }

    public byte[]? UpdateBy { get; set; }

    public string? Username { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ParentDetail? ParentDetail { get; set; }

    public virtual ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();

    public virtual ICollection<PostLike> PostLikes { get; set; } = new List<PostLike>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual TeacherDetail? TeacherDetail { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
