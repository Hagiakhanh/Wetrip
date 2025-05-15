using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class TemporaryGroupMessageMedium
{
    public int MessageId { get; set; }

    public string? MediaUrl { get; set; }

    public virtual TemporaryGroupMessage Message { get; set; } = null!;
}
