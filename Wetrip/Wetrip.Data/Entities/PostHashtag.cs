using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class PostHashtag
{
    public int PostId { get; set; }

    public int HashtagId { get; set; }

    public string? RawText { get; set; }

    public virtual Hashtag Hashtag { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;
}
