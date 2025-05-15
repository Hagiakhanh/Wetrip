using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class SharedPost
{
    public int SharedPostId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Message { get; set; }

    public int PostId { get; set; }

    public int UserSharedId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User UserShared { get; set; } = null!;
}
