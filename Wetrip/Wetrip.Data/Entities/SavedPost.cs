using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class SavedPost
{
    public int SavedPostId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public int PostId { get; set; }

    public int UserSavedPostId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User UserSavedPost { get; set; } = null!;
}
