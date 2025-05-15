using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class ConfirmedGroupMessage
{
    public int MessageId { get; set; }

    public int GroupId { get; set; }

    public int SenderId { get; set; }

    public string? MessageType { get; set; }

    public DateTime SentAt { get; set; }

    public virtual ConfirmedGroupMessageLocation? ConfirmedGroupMessageLocation { get; set; }

    public virtual ConfirmedGroupMessageMedium? ConfirmedGroupMessageMedium { get; set; }

    public virtual ConfirmedGroupMessageText? ConfirmedGroupMessageText { get; set; }

    public virtual ConfirmedGroup Group { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;
}
