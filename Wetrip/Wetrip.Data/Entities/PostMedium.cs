using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class PostMedium
{
    public int PostMediaId { get; set; }

    public string Url { get; set; } = null!;

    public int PostId { get; set; }

    public virtual Post Post { get; set; } = null!;
}
