using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class ConfirmedGroupMessageText
{
    public int MessageId { get; set; }

    public string? MessageText { get; set; }

    public virtual ConfirmedGroupMessage Message { get; set; } = null!;
}
