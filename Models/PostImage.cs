using System;
using System.Collections.Generic;

namespace Cimo.Models;

public partial class PostImage
{
    public int Id { get; set; }

    public int? ImageIndex { get; set; }

    public byte[] PostId { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;
}
