using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class TemporaryGroupMessage
{
    public int MessageId { get; set; }

    public int GroupId { get; set; }

    public int SenderId { get; set; }

    public string? MessageType { get; set; }

    public DateTime SentAt { get; set; }

    public virtual TemporaryGroup Group { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;

    public virtual TemporaryGroupMessageLocation? TemporaryGroupMessageLocation { get; set; }

    public virtual TemporaryGroupMessageMedium? TemporaryGroupMessageMedium { get; set; }

    public virtual TemporaryGroupMessageText? TemporaryGroupMessageText { get; set; }
}
