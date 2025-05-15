using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class Like
{
    public int LikeId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public int PostId { get; set; }

    public int UserLikedId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User UserLiked { get; set; } = null!;
}
