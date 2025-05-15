using System;
using System.Collections.Generic;

namespace Wetrip.Data.Entities;

public partial class TemporaryGroup
{
    public int TemporaryGroupId { get; set; }

    public int CompanionTripId { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual CompanionTrip CompanionTrip { get; set; } = null!;

    public virtual TemporaryGroupMember? TemporaryGroupMember { get; set; }

    public virtual TemporaryGroupMessage? TemporaryGroupMessage { get; set; }
}
