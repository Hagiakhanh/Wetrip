using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string Title { get; set; } = null!;

    public string? Body { get; set; }

    public string? Image { get; set; }

    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
