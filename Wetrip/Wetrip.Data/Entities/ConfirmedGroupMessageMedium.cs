using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class ConfirmedGroupMessageMedium
{
    public int MessageId { get; set; }

    public string? MediaUrl { get; set; }

    public virtual ConfirmedGroupMessage Message { get; set; } = null!;
}
